using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace RedfieldWeather.API.Models.Weather
{
	public class WeatherEntity<TReported> : TableEntity
	{
		public WeatherEntity()
		{
		}

		public WeatherEntity(TReported weather)
		{
			var nowUtc = DateTime.UtcNow;
			var ticks = DateTime.MaxValue.Ticks - nowUtc.Ticks;
			var type = typeof (TReported) == typeof (Conditions.Reported) ? 0 : 1;

			PartitionKey = $"WF:{nowUtc:yyyy-MM-dd}";
			RowKey = $"{type:N0}:{ticks:D19}";

			UpdateJson(weather);
		}

		public void UpdateJson(TReported weather)
		{
			Json = Newtonsoft.Json.JsonConvert.SerializeObject(weather);
		}

		public string Json { get; set; }

		public TReported ConvertFromJson()
		{
			return Newtonsoft.Json.JsonConvert.DeserializeObject<TReported>(Json);
		}
	}
}
