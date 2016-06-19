using System;

namespace RedfieldWeather.API.Models.Weather.Conditions
{
	[Serializable]
	public class Temperature
	{
		public decimal Degrees { get; set; }
		public decimal Rate { get; set; }
	
		public decimal Dewpoint { get; set; }
		public decimal DewpointRate { get; set; }
		
		public decimal HeatIndex { get; set; }
		public decimal HeatIndexRate { get; set; }
		
		public decimal WindChill { get; set; }
		public decimal WindChillRate { get; set; }
		
		public decimal Evaportranspiration { get; set; }
		public decimal EvaportranspirationRate { get; set; }


		public override string ToString()
		{
			return $"{Degrees:N2} {(Rate < 0 ? "Falling" : "Rising")}";
		}
	}
}
