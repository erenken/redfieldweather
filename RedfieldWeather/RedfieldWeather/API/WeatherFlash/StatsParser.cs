using System;
using RedfieldWeather.API.Models.Weather;
using RedfieldWeather.API.ExtensionMethods;
using RedfieldWeather.API.Models.Weather.Stats;

namespace RedfieldWeather.API.WeatherFlash
{
	public class StatsParser : IWeatherParser<Reported>
	{
		public Reported Parse(string data)
		{
			Reported reported = new Reported();

			string[] values = data.Split(',');

			reported.Wind = new Wind
			{
				SpeedHigh = new HighLow
				{
					Value = values[31].ToDecimal(),
					Time = values[59].ToDateTime()
				},
				SpeedLow = new HighLow
				{
					Value = values[87].ToDecimal(),
					Time = values[115].ToDateTime()
				},
				GustHigh = new HighLow
				{
					Value = values[32].ToDecimal(),
					Time = values[60].ToDateTime()
				},
				GustLow = new HighLow
				{
					Value = values[88].ToDecimal(),
					Time = values[116].ToDateTime()
				},
				WindRun = values[258].ToDecimal(),
				WindRunMonth = values[265].ToDecimal(),
				WindRunYear = values[268].ToDecimal()
			};

			reported.InHumidity = new Humidity
			{
				High = new HighLow
				{
					Value = values[33].ToDecimal(),
					Time = values[61].ToDateTime()
				},
				Low = new HighLow
				{
					Value = values[89].ToDecimal(),
					Time = values[117].ToDateTime()
				}
			};

			reported.Humidity = new Humidity
			{
				High = new HighLow
				{
					Value = values[34].ToDecimal(),
					Time = values[62].ToDateTime()
				},
				Low = new HighLow
				{
					Value = values[90].ToDecimal(),
					Time = values[118].ToDateTime()
				}
			};

			reported.InTemperature = new Temperature
			{
				High = new HighLow
				{
					Value = values[35].ToDecimal(),
					Time = values[63].ToDateTime()
				},
				Low = new HighLow
				{
					Value = values[91].ToDecimal(),
					Time = values[119].ToDateTime()
				},
				HeatIndexHigh = new HighLow
				{
					Value = values[49].ToDecimal(),
					Time = values[77].ToDateTime()
				}
			};

			reported.Temperature = new Temperature
			{
				High = new HighLow
				{
					Value = values[36].ToDecimal(),
					Time = values[64].ToDateTime()
				},
				Low = new HighLow
				{
					Value = values[92].ToDecimal(),
					Time = values[120].ToDateTime()
				},
				HeatIndexHigh = new HighLow
				{
					Value = values[50].ToDecimal(),
					Time = values[78].ToDateTime()
				},
				WindChillHigh = new HighLow
				{
					Value = values[48].ToDecimal(),
					Time = values[76].ToDateTime()
				}
			};

			reported.Barometer = new Barometer
			{
				RawHigh = new HighLow
				{
					Value = values[37].ToDecimal(),
					Time = values[65].ToDateTime()
				},
				RawLow = new HighLow
				{
					Value = values[93].ToDecimal(),
					Time = values[121].ToDateTime()
				}
			};

			reported.Solar = new Solar
			{
				RadiationHigh = new HighLow
				{
					Value = values[47].ToDecimal(),
					Time = values[77].ToDateTime()
				},
				UVIndexHigh = new HighLow
				{
					Value = values[46].ToDecimal(),
					Time = values[76].ToDateTime()
				}
			};


			reported.Rain = new Rain
			{
				Daily = values[254].ToDecimal(),
				Hourly = values[255].ToDecimal(),
				TwentyFourHour = values[256].ToDecimal(),
				Rate = values[257].ToDecimal(),
				Monthly = values[262].ToDecimal()
			};

			reported.Forecast = new Forecast
			{
				HeatStress = values[269].UrlDecode(),
				ComformatLevel = values[270].UrlDecode(),
				Value = values[271].UrlDecode(),
				BarometerTrend = values[272].UrlDecode(),
				PressureTrend = values[273].UrlDecode(),
				BeaufortScale = values[274].UrlDecode()
			};

			return reported;
		}
	}
}
