namespace CloudFlare.Client.Models
{
    public class ApiTokenAuthentication
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
    }
}