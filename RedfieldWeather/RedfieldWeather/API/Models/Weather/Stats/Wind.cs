using System;

namespace RedfieldWeather.API.Models.Weather.Stats
{
	[Serializable]
	public class Wind
	{
		public HighLow SpeedHigh { get; set; }
		public HighLow SpeedLow { get; set; }
	
		public HighLow GustHigh { get; set; }
		public HighLow GustLow { get; set; }

		public decimal WindRun { get; set; }
		public decimal WindRunMonth { get; set; }
		public decimal WindRunYear { get; set; }


		public override string ToString()
		{
			return $"{SpeedHigh:N2} High";
		}
	}
}
