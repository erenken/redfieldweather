using System;

namespace RedfieldWeather.API.Models.Weather.Stats
{
	[Serializable]
	public class Humidity
	{
		public HighLow High { get; set; }
		public HighLow Low { get; set; }

		public override string ToString()
		{
			return $"{High.Value:N2}% High";
		}
	}
}
