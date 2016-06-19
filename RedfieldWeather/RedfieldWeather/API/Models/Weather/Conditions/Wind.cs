using System;

namespace RedfieldWeather.API.Models.Weather.Conditions
{
	[Serializable]
	public class Wind
	{
		public string DirectionDescription { get; set; }
		public decimal Direction { get; set; }
		public decimal DirectionRate { get; set; }

		public decimal Speed { get; set; }
		public decimal SpeedRate { get; set; }
	
		public decimal Gust { get; set; }
		public decimal GustRate { get; set; }

		public override string ToString()
		{
			return $"{Speed:N2} {DirectionDescription}";
		}
	}
}
