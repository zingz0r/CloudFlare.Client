using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Accounts
{
    /// <summary>
    /// Legacy flags
    /// </summary>
    public class LegacyFlags
    {
        /// <summary>
        /// Enterprise zone quota
        /// </summary>
        [JsonPropertyName("enterprise_zone_quota")]
        public EnterpriseZoneQuota EnterpriseZoneQuota { get; set; }
    }
}
