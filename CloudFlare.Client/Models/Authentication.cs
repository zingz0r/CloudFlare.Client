using System.Security.Authentication;

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

        public Authentication(string emailAddress, string apiKey)
        {
            Email = emailAddress;
            ApiKey = apiKey;
        }
    }
}