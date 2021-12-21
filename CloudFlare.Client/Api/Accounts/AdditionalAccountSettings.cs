using System;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts
{
    /// <summary>
    /// Additional account settings
    /// </summary>
    public class AdditionalAccountSettings
    {
        /// <summary>
        /// Indicates whether or not membership in this account requires that Two-Factor Authentication is enabled
        /// </summary>
        [JsonProperty("enforce_twofactor")]
        public bool EnforceTwoFactorAuthentication { get; set; }

        /// <summary>
        /// Access approval expiry date
        /// </summary>
        [JsonProperty("access_approval_expiry")]
        public DateTime? AccessApprovalExpiry { get; set; }
    }
}
