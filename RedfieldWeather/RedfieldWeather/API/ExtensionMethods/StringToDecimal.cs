using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedfieldWeather.API.ExtensionMethods
{
	public static class StringToDecimal
	{
		public static decimal ToDecimal(this string str)
		{
			decimal output = 0M;
			decimal.TryParse(str, out output);

			return output;
		}
	}
}
