using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class AccountSettings
    {
        /// <summary>
        /// Indicates whether or not membership in this account requires that Two-Factor Authentication is enabled
        /// </summary>
        [JsonProperty("enforce_twofactor")]
        public bool EnforceTwofactor { get; set; }
    }
}