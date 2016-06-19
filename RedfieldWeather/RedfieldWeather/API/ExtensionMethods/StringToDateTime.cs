using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedfieldWeather.API.ExtensionMethods
{
	public static class StringToDateTime
	{
		public static DateTime ToDateTime(this string str)
		{
			DateTime output = new DateTime(0);
			DateTime.TryParse(str, out output);

			return output;
		}
	}
}
