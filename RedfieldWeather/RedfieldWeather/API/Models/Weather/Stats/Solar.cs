using System;

namespace RedfieldWeather.API.Models.Weather.Stats
{
	[Serializable]
	public class Solar
	{
		public HighLow RadiationHigh { get; set; }

		public HighLow UVIndexHigh { get; set; }

		public override string ToString()
		{
			return $"{RadiationHigh.Value:N2} {UVIndexHigh.Value:N2}";
		}
	}
}
