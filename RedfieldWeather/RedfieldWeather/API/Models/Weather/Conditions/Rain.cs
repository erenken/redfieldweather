using System;

namespace RedfieldWeather.API.Models.Weather.Conditions
{
	[Serializable]
	public class Rain
	{
		public decimal YearlyTotal { get; set; }

		public override string ToString()
		{
			return $"{YearlyTotal:N2} yearly total";
		}
	}
}
