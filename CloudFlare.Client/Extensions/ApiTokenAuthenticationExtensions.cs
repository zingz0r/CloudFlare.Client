using System.Security.Authentication;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Extensions
{
    public static class ApiTokenAuthenticationExtensions
    {
        public static void EnsureTokenHasBeenSet(this ApiTokenAuthentication auth)
        {
            if (string.IsNullOrEmpty(auth.ApiToken))
            {
                throw new AuthenticationException("Empty credentials! You must set email address and api key.");
            }
        }
    }
}