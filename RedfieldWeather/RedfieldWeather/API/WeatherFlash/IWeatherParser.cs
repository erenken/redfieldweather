using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedfieldWeather.API.Models.Weather;
using RedfieldWeather.API.Models.Weather.Conditions;

namespace RedfieldWeather.API.WeatherFlash
{
	public interface IWeatherParser<out TReported>
	{
		TReported Parse(string data);
	}
}
