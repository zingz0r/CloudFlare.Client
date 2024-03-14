using System.Text.Json.Serialization;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones
{
    /// <summary>
    /// New zone
    /// </summary>
    public class NewZone
    {
        /// <summary>
        /// The domain name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Information about the account the zone belongs to
        /// </summary>
        [JsonPropertyName("account")]
        public Account Account { get; set; }

        /// <summary>
        /// A full zone implies that DNS is hosted with CloudFlare. A partial zone is typically a partner-hosted zone or a CNAME setup.
        /// </summary>
        [JsonPropertyName("type")]
        public ZoneType Type { get; set; }

        /// <summary>
        /// Whether you want automatically attempt to fetch existing DNS records
        /// </summary>
        [JsonPropertyName("jump_start")]
        public bool JumpStart { get; set; }
    }
}
