using System;

namespace RedfieldWeather.API.Models.Weather.Conditions
{
	[Serializable]
	public class Solar
	{
		public decimal Radiation { get; set; }
		public decimal RadiationRate { get; set; }

		public decimal UVIndex { get; set; }
		public decimal UVIndexRate { get; set; }

		public override string ToString()
		{
			return $"{Radiation:N2} {UVIndex:N2}";
		}
	}
}
