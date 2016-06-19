namespace RedfieldWeather.API.ExtensionMethods
{
	public static class StringToUrlDecode
	{
		public static string UrlDecode(this string str)
		{
			return System.Web.HttpUtility.UrlDecode(str);
		}
	}
}
