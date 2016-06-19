using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace RedfieldWeather.webJob
{
	public class Functions
	{
		public static async void UpdateMLDNTimelapse([TimerTrigger("00:05:00", RunOnStartup = true)] TimerInfo timerInfo)
		{
			using (HttpClient client = new HttpClient())
			{
				await client.GetAsync("http://www.redfieldweather.com/mldn/index.php?f=creategif");
			}
		}
	}
}