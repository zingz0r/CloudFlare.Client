namespace CloudFlare.Client.Models
{
    public class Authentication
    {
        /// <summary>
        /// Email Address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// CloudFlare API Key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// CloudFlare API Token
        /// </summary>
        public string ApiToken { get; set; }

        public Authentication(string emailAddress, string apiKey, string apiToken)
        {
            Email = emailAddress;
            ApiKey = apiKey;
            ApiToken = apiToken;
        }

        public Authentication()
        {
            
        }
    }
}