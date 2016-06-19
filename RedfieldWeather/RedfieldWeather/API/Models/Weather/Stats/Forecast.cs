using System;

namespace RedfieldWeather.API.Models.Weather.Stats
{
	[Serializable]
	public class Forecast
	{
		public string HeatStress { get; set; }
		public string ComformatLevel { get; set; }
		public string Value { get; set; }
		public string BarometerTrend { get; set; }
		public string PressureTrend { get; set; }
		public string BeaufortScale { get; set; }

		public override string ToString()
		{
			return Value;
		}
	}
}
