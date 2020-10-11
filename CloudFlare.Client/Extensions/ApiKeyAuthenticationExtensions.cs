using System.Security.Authentication;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Extensions
{
    public static class ApiKeyAuthenticationExtensions
    {
        public static void EnsureCredentialsHasBeenSet(this ApiKeyAuthentication auth)
        {
            if (string.IsNullOrEmpty(auth.Email) || string.IsNullOrEmpty(auth.ApiKey))
            {
                throw new AuthenticationException("Empty credentials! You must set email address and api key.");
            }
        }
    }
}