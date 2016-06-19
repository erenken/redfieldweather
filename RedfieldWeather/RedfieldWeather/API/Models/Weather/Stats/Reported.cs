using System;
using RedfieldWeather.API.Models.Weather.Conditions;

namespace RedfieldWeather.API.Models.Weather.Stats
{
	public class Reported
	{
		public Wind Wind { get; set; }
		public Humidity InHumidity { get; set; }
		public Humidity Humidity { get; set; }
		public Temperature InTemperature { get; set; }
		public Temperature Temperature { get; set; }
		public Barometer Barometer { get; set; }
		public Rain Rain { get; set; }
		public Solar Solar { get; set; }
		public Forecast Forecast { get; set; }
	}
}
