using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.KeyVault;
using System.Configuration;
using Microsoft.Win32;

namespace RedfieldWeather.Common
{
	public class AzureStorage
	{
		public static string ConnectionString { get; set; }

		public async static Task<string> GetToken(string authority, string resource, string scope)
		{
			var authContext = new AuthenticationContext(authority);

			var clientId = GetConfiguration("ClientId");
			var clientSecret = GetConfiguration("ClientSecret");

			ClientCredential clientCred = new ClientCredential(clientId, clientSecret);
			AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

			if (result == null)
				throw new InvalidOperationException("Failed to obtain the JWT token");

			return result.AccessToken;
		}

		public async static Task SetConnectionString()
		{
			var keyVault = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(AzureStorage.GetToken));
			var secret = await keyVault.GetSecretAsync(GetConfiguration("SecretUri"));

			AzureStorage.ConnectionString = secret.Value;
		}

		private static string GetConfiguration(string key)
		{
			var value = ConfigurationManager.AppSettings[key];
			if (string.IsNullOrWhiteSpace(value))
				value = Registry.LocalMachine.OpenSubKey("SOFTWARE\\mynoc\\RedfieldWeather").GetValue($"{key}", "").ToString();

			System.Diagnostics.Debug.WriteLine($"Key: {key} Value: {value}");

			return value;
		}
	}
}
