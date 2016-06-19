using System;

namespace RedfieldWeather.API.Models.Weather
{
	[Serializable]
	public class HighLow
	{
		public decimal Value { get; set; }
		public DateTime Time { get; set; }

		public override string ToString()
		{
			return $"{Value:N2} {Time:t}";
		}
	}
}
