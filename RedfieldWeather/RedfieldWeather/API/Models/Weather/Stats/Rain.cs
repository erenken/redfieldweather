using System;

namespace RedfieldWeather.API.Models.Weather.Stats
{
	[Serializable]
	public class Rain
	{
		public decimal Rate { get; set; }
		public decimal Daily { get; set; }
		public decimal Hourly { get; set; }
		public decimal TwentyFourHour { get; set; }
		public decimal Monthly { get; set; }

		public override string ToString()
		{
			return $"{Daily:N2} {Rate:N2}";
		}
	}
}
