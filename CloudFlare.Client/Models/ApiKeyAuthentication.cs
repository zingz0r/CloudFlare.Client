namespace CloudFlare.Client.Models
{
    public class ApiKeyAuthentication
    {
        /// <summary>
        /// Email Address
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// CloudFlare API Key
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Authenticate with Email and Global API Key
        /// </summary>
        /// <param name="emailAddress">Email Address</param>
        /// <param name="apiKey">Global Api Key</param>

        public ApiKeyAuthentication(string emailAddress, string apiKey)
        {
            Email = emailAddress;
            ApiKey = apiKey;
        }
    }
}