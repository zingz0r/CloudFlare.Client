using System;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("enforce_twofactor")]
        public bool EnforceTwoFactorAuthentication { get; set; }

        /// <summary>
        /// Access approval expiry date
        /// </summary>
        [JsonPropertyName("access_approval_expiry")]
        public DateTime? AccessApprovalExpiry { get; set; }
    }
}
