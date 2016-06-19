using System;

namespace RedfieldWeather.API.Models.Weather.Conditions
{
	[Serializable]
	public class Barometer
	{
		public decimal Raw { get; set; }
		public decimal SL { get; set; }
		public decimal RawRate { get; set; }
		public decimal SLRate { get; set; }

		public override string ToString()
		{
			return $"{Raw:N2} {(RawRate < 0 ? "Falling" : "Rising")}";
		}
	}
}
