using System;

namespace RedfieldWeather.API.Models.Weather.Stats
{
	[Serializable]
	public class Barometer
	{
		public HighLow RawHigh { get; set; }
		public HighLow RawLow { get; set; }

		public override string ToString()
		{
			return $"{RawHigh.Value:N2} {RawLow.Value:N2}";
		}
	}
}
