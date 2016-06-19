using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using RedfieldWeather.API.Action;
using RedfieldWeather.API.Models;
using RedfieldWeather.API.WeatherFlash;

namespace RedfieldWeather.Controllers
{
	[RoutePrefix("api/weatherFlash")]
    public class WeatherFlashController : ApiController
    {
	    [HttpGet]
		[Route("push")]
	    public async Task<IHttpActionResult> Push(string i = null, string f = null, string s = null)
	    {
		    if (string.IsNullOrWhiteSpace(i) || !i.Equals(ConfigurationManager.AppSettings["WeatherFlash"], StringComparison.CurrentCultureIgnoreCase))
			    return Unauthorized();

		    if (!string.IsNullOrWhiteSpace(f))
		    {
				WeatherFlash<API.Models.Weather.Conditions.Reported, ConditionsParser> weatherFlash = new WeatherFlash<API.Models.Weather.Conditions.Reported, ConditionsParser>();
				await weatherFlash.SaveReport(f);
		    }
		    else if (!string.IsNullOrWhiteSpace(s))
			{
				WeatherFlash<API.Models.Weather.Stats.Reported, StatsParser> weatherFlash = new WeatherFlash<API.Models.Weather.Stats.Reported, StatsParser>();
				await weatherFlash.SaveReport(s);
			}
		    else
			    return BadRequest("Missing Forecase or Stats");

		    return Ok();
	    }

		[HttpGet]
		[Route("latest")]
		[ResponseType(typeof(WeatherData))]
		public async Task<IHttpActionResult> Latest()
		{
			WeatherFlash<API.Models.Weather.Conditions.Reported, ConditionsParser> getConditions = new WeatherFlash<API.Models.Weather.Conditions.Reported, ConditionsParser>();
			var conditonsTask = getConditions.GetMostRecentEntry();

			WeatherFlash<API.Models.Weather.Stats.Reported, StatsParser> getStats = new WeatherFlash<API.Models.Weather.Stats.Reported, StatsParser>();
			var statsTask = getStats.GetMostRecentEntry();

			await Task.WhenAll(conditonsTask, statsTask);

			WeatherData data = new WeatherData();
			data.Conditions = conditonsTask.Result.ConvertFromJson();
			data.Stats = statsTask.Result.ConvertFromJson();

			return Ok(data);
		}

		[HttpGet]
		[Route("history/last/{days:int}")]
		[ResponseType(typeof(WeatherData[]))]
		public async Task<IHttpActionResult> Last(int days)
		{
			WeatherFlash<API.Models.Weather.Conditions.Reported, ConditionsParser> getConditions = new WeatherFlash<API.Models.Weather.Conditions.Reported, ConditionsParser>();
			var conditionsTask = getConditions.GetLastDaysEntries(days);

			WeatherFlash<API.Models.Weather.Stats.Reported, StatsParser> getStats = new WeatherFlash<API.Models.Weather.Stats.Reported, StatsParser>();
			var statsTask = getStats.GetLastDaysEntries(days);

			await Task.WhenAll(conditionsTask, statsTask);

			List<WeatherData> data = new List<WeatherData>();

			var conditions = conditionsTask.Result;
			var stats = statsTask.Result;

			for (int i = 0; i < conditions.Count && i < stats.Count; i++)
			{
				data.Add(new WeatherData
				{
					Conditions = conditions[i].ConvertFromJson(),
					Stats = stats[i].ConvertFromJson()
				});
			}

			return Ok(data.ToArray());
		}
	}
}
