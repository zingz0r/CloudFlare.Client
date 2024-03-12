using System.Text.Json.Serialization;

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
        [JsonPropertyName("maximum")]
        public long Maximum { get; set; }

        /// <summary>
        /// Current quota
        /// </summary>
        [JsonPropertyName("current")]
        public long Current { get; set; }

        /// <summary>
        /// Available quota
        /// </summary>
        [JsonPropertyName("available")]
        public long Available { get; set; }
    }
}
