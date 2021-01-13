using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts
{
    public class LegacyFlags
    {
        /// <summary>
        /// Enterprise zone quota
        /// </summary>
        [JsonProperty("enterprise_zone_quota")]
        public EnterpriseZoneQuota EnterpriseZoneQuota { get; set; }
    }
}