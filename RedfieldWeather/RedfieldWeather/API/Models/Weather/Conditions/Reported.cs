using System;

namespace RedfieldWeather.API.Models.Weather.Conditions
{
	[Serializable]
	public class Reported
	{
		public DateTime TimeStamp { get; set; }
		public DateTime TimeOfUpdate { get; set; }
		public Wind Wind { get; set; }
		public Humidity InHumidity { get; set; }
		public Humidity Humidity { get; set; }
		public Temperature InTemperature { get; set; }
		public Temperature Temperature { get; set; }
		public Barometer Barometer { get; set; }
		public Rain Rain { get; set; }
		public Solar Solar { get; set; }

		public decimal PressureAltitude { get; set; }
		public decimal CloudBase { get; set; }
		public decimal DensityAltitude { get; set; }
		public decimal VirtualTemperature { get; set; }
		public decimal VaporPressure { get; set; }
	}
}
