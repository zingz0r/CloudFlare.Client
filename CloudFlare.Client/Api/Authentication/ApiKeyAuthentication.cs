using System.Net.Http;
using System.Security.Authentication;

namespace CloudFlare.Client.Api.Authentication
{
    /// <summary>
    /// For authenticating with Email address and API key
    /// </summary>
    public class ApiKeyAuthentication : IAuthentication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiKeyAuthentication"/> class
        /// </summary>
        /// <param name="emailAddress">Email Address</param>
        /// <param name="apiKey">Global Api Key</param>
        public ApiKeyAuthentication(string emailAddress, string apiKey)
        {
            Email = emailAddress;
            ApiKey = apiKey;

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(ApiKey))
            {
                throw new AuthenticationException("Empty credentials! You must set email address and api key.");
            }
        }

        /// <summary>
        /// Email Address
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// CloudFlare API Key
        /// </summary>
        public string ApiKey { get; }

        /// <inheritdoc />
        public void AddToHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Add(AuthenticationHeader.EmailHeader, Email);
            client.DefaultRequestHeaders.Add(AuthenticationHeader.KeyHeader, ApiKey);
        }
    }
}
