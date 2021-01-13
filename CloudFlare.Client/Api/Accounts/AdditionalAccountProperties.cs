using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts
{
    public class AdditionalAccountProperties
    {
        /// <summary>
        /// Indicates whether or not membership in this account requires that Two-Factor Authentication is enabled
        /// </summary>
        [JsonProperty("enforce_twofactor")]
        public bool EnforceTwoFactorAuthentication { get; set; }
    }
}