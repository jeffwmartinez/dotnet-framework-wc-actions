using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace AzureServiceHelper
{
    public class KeyVaultService
    {
        public static string AZURECONSTRING { get; set; }

        public static async Task<string> GetToken(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(ConfigurationManager.AppSettings["ClientId"], ConfigurationManager.AppSettings["ClientSecret"]);
            AuthenticationResult AuthResult = await authContext.AcquireTokenAsync(resource, clientCred);
            if (AuthResult == null)
                throw new InvalidOperationException("Failed to Obtain JWT token.");
            return AuthResult.AccessToken;
        }

    }
}
