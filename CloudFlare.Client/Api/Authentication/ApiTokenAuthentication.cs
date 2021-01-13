using System.Net.Http;
using System.Security.Authentication;

namespace CloudFlare.Client.Api.Authentication
{
    public class ApiTokenAuthentication : IAuthentication
    {
        /// <summary>
        /// CloudFlare API Token
        /// </summary>
        public string ApiToken { get; }


        /// <summary>
        /// Authenticate with API Token
        /// </summary>
        /// <param name="apiToken">Api Token</param>
        public ApiTokenAuthentication(string apiToken)
        {
            ApiToken = apiToken;

            if (string.IsNullOrEmpty(apiToken))
            {
                throw new AuthenticationException("Empty token! You must set the token.");
            }
        }

        /// <inheritdoc />
        public void AddToHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiToken);
        }
    }
}