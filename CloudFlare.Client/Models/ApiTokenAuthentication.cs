using System.Net.Http;

namespace CloudFlare.Client.Models
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
        }

        /// <inheritdoc />
        public void AddToHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiToken);
        }
    }
}