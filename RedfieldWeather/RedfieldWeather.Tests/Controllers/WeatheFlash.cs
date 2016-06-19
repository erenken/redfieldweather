using System;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedfieldWeather.Controllers;

namespace RedfieldWeather.Tests.Controllers
{
	[TestClass]
	public class WeatheFlash
	{
		[TestMethod]
		public async Task Update_SendBadIdenityKey_ReturnsUnautherized()
		{
			RedfieldWeather.Controllers.WeatherFlashController weatherFlash = new WeatherFlashController();
			var result = await weatherFlash.Push("AASASDA", null, null);

			Assert.IsInstanceOfType(result, typeof(UnauthorizedResult));
		}
	}
}
