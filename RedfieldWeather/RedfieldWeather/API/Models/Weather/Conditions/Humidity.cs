using System;

namespace RedfieldWeather.API.Models.Weather.Conditions
{
	[Serializable]
	public class Humidity
	{
		public decimal Percentage { get; set; }
		public decimal Rate { get; set; }

		public override string ToString()
		{
			return $"{Percentage:N2}%";
		}
	}
}
