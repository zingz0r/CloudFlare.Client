using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts
{
    /// <summary>
    /// Enterprise zone quota
    /// </summary>
    public class EnterpriseZoneQuota
    {
        /// <summary>
        /// Maximum quota
        /// </summary>
        [JsonProperty("maximum")]
        public long Maximum { get; set; }

        /// <summary>
        /// Current quota
        /// </summary>
        [JsonProperty("current")]
        public long Current { get; set; }

        /// <summary>
        /// Available quota
        /// </summary>
        [JsonProperty("available")]
        public long Available { get; set; }
    }
}
