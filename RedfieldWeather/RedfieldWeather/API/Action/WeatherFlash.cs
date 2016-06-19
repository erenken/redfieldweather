using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.Queryable;
using RedfieldWeather.API.Models.Weather;
using RedfieldWeather.API.WeatherFlash;
using RedfieldWeather.Common;

namespace RedfieldWeather.API.Action
{
	public class WeatherFlash<TReported, TParser> where TParser : IWeatherParser<TReported>, new()
	{
		private CloudStorageAccount _storageAccount = CloudStorageAccount.Parse(AzureStorage.ConnectionString);

		public async Task SaveReport(string report)
		{
			var table = await GetTable();

			IWeatherParser<TReported> weatherParser = new TParser();

			var weather = weatherParser.Parse(report);
			WeatherEntity<TReported> weatherEntity = new WeatherEntity<TReported>(weather);


			TableOperation insertOperation = TableOperation.InsertOrReplace(weatherEntity);
			await table.ExecuteAsync(insertOperation);
		}

		private async Task<CloudTable> GetTable()
		{
			CloudTableClient tableClient = _storageAccount.CreateCloudTableClient();
			CloudTable table = tableClient.GetTableReference("weather");
			await table.CreateIfNotExistsAsync();

			return table;
		}

		public async Task<WeatherEntity<TReported>> GetMostRecentEntry()
		{
			var table = await GetTable();

			var nowUtc = DateTime.UtcNow;
			var lowerTicks = DateTime.MaxValue.Ticks - nowUtc.AddMinutes(-2).Ticks;
			var upperTicks = DateTime.MaxValue.Ticks - nowUtc.AddMinutes(2).Ticks;
			var type = typeof (TReported) == typeof (Models.Weather.Conditions.Reported) ? 0 : 1;

			var partitionKey = $"WF:{nowUtc:yyyy-MM-dd}";
			var rowKeyLower = $"{type:N0}:{lowerTicks:D19}";
			var rowKeyHigher = $"{type:N0}:{upperTicks:D19}";

			var tableQuery = table.CreateQuery<WeatherEntity<TReported>>().Where(
				x => x.PartitionKey == partitionKey
				     && x.RowKey.CompareTo(rowKeyLower) <= 0
				     && x.RowKey.CompareTo(rowKeyHigher) >= 0
				).Take(1).AsTableQuery();

			var weatherEntity = (await ExecuteSegmentedQuery(table, tableQuery)).OrderByDescending(x => x.Timestamp).FirstOrDefault();

			return weatherEntity;
		}

		public async Task<List<WeatherEntity<TReported>>> GetLastDaysEntries(int days)
		{
			var table = await GetTable();
			var type = typeof(TReported) == typeof(Models.Weather.Conditions.Reported) ? 0 : 1;

			if (days > 0)
				days = days*-1;

			var nowUtc = DateTime.UtcNow.AddDays(days);

			var partitionKey = $"WF:{nowUtc:yyyy-MM-dd}";
			var rowKeyLower = $"{type:N0}:";
			var rowKeyHigher = $"{type + 1:N0}:";

			var tableQuery = table.CreateQuery<WeatherEntity<TReported>>().Where(
				x => x.PartitionKey.CompareTo(partitionKey) >= 0 
					&& x.RowKey.CompareTo(rowKeyLower) >= 0 
					&& x.RowKey.CompareTo(rowKeyHigher) < 0
				).AsTableQuery();
			var weatherEntity = (await ExecuteSegmentedQuery(table, tableQuery)).OrderByDescending(x => x.Timestamp);

			return weatherEntity.ToList();
		}

		private async Task<List<WeatherEntity<TReported>>> ExecuteSegmentedQuery(CloudTable table, TableQuery<WeatherEntity<TReported>> query)
		{
			var segments = new List<TableQuerySegment<WeatherEntity<TReported>>>();

			var token = new TableContinuationToken();

			try
			{
				while (token != null)
				{
					var currentSegment = await table.ExecuteQuerySegmentedAsync(query, token);
					token = currentSegment.ContinuationToken;

					segments.Add(currentSegment);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
				throw;
			}

			var allResults = segments.SelectMany(x => x.Results).ToList();

			return allResults;
		}
	}
}
