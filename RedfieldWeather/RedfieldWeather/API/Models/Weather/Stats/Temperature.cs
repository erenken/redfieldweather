using System;

namespace RedfieldWeather.API.Models.Weather.Stats
{
	[Serializable]
	public class Temperature
	{
		public HighLow High { get; set; }
		public HighLow Low { get; set; }
	
		public HighLow HeatIndexHigh { get; set; }
		
		public HighLow WindChillHigh { get; set; }
		
		public override string ToString()
		{
			return $"{High.Value:N2} Degrees";
		}
	}
}
