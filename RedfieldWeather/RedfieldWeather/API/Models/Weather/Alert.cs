using System;

namespace RedfieldWeather.API.Models.Weather
{
	[Serializable]
	public class Alert
	{
		private string _message = string.Empty;

		public string Type { get; set; }
		public string Description { get; set; }
		public string DateTime { get; set; }
		public string Expires { get; set; }

		public string Message
		{
			get { return _message.Replace("...", "\n"); }
			set { _message = value; }
		}
	}
}
