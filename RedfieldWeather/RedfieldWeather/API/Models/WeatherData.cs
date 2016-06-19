using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedfieldWeather.API.Models
{
	[Serializable]
	public class WeatherData
	{
		public Weather.Conditions.Reported Conditions { get; set; }
		public Weather.Stats.Reported Stats { get; set; }
	}
}
