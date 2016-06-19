using System;
using RedfieldWeather.API.Models.Weather;
using RedfieldWeather.API.ExtensionMethods;
using RedfieldWeather.API.Models.Weather.Conditions;

namespace RedfieldWeather.API.WeatherFlash
{
	public class ConditionsParser : IWeatherParser<Reported>
	{
		public Reported Parse(string data)
		{
			Reported conditions = new Reported();
			string[] values = data.Split(',');

			conditions.TimeStamp = new DateTime(1900, 1, 1).AddSeconds(Convert.ToInt64(values[0]));
			conditions.TimeOfUpdate = Convert.ToDateTime(values[1].UrlDecode());

			conditions.Wind = new Wind
			{
				DirectionDescription = values[2],
				Direction = values[3].ToDecimal(),
				DirectionRate = values[31].ToDecimal(),
				Speed = values[4].ToDecimal(),
				SpeedRate = values[32].ToDecimal(),
				Gust = values[5].ToDecimal(),
				GustRate = values[33].ToDecimal()
			};

			conditions.InHumidity = new Humidity
			{
				Percentage = values[6].ToDecimal(),
				Rate = values[34].ToDecimal()
			};

			conditions.Humidity = new Humidity
			{
				Percentage = values[7].ToDecimal(),
				Rate = values[35].ToDecimal()
			};

			conditions.InTemperature = new Temperature
			{
				Degrees = values[8].ToDecimal(),
				Rate = values[36].ToDecimal(),
				HeatIndex = values[22].ToDecimal(),
				HeatIndexRate = values[50].ToDecimal()
			};

			conditions.Temperature = new Temperature
			{
				Degrees = values[9].ToDecimal(),
				Rate = values[37].ToDecimal(),
				HeatIndex = values[23].ToDecimal(),
				HeatIndexRate = values[51].ToDecimal(),
				Dewpoint = values[24].ToDecimal(),
				DewpointRate = values[52].ToDecimal(),
				WindChill = values[21].ToDecimal(),
				WindChillRate = values[49].ToDecimal(),
				Evaportranspiration = values[18].ToDecimal(),
				EvaportranspirationRate = values[46].ToDecimal()
			};

			conditions.Rain = new Rain
			{
				YearlyTotal = values[11].ToDecimal()
			};

			conditions.Barometer = new Barometer
			{
				Raw = values[10].ToDecimal(),
				RawRate = values[38].ToDecimal(),
				SL = values[25].ToDecimal(),
				SLRate = values[53].ToDecimal()
			};

			conditions.Solar = new Solar
			{
				UVIndex = values[19].ToDecimal(),
				UVIndexRate = values[47].ToDecimal(),
				Radiation = values[20].ToDecimal(),
				RadiationRate = values[48].ToDecimal()
			};


			conditions.PressureAltitude = values[26].ToDecimal();
			conditions.CloudBase = values[27].ToDecimal();
			conditions.DensityAltitude = values[28].ToDecimal();
			conditions.VirtualTemperature = values[29].ToDecimal();
			conditions.VaporPressure = values[30].ToDecimal();

			return conditions;
		}
	}
}
