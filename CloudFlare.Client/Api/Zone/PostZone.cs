using Newtonsoft.Json;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Api.Zone
{
    public class PostZone
    {
        /// <summary>
        /// Zone id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The domain name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Information about the account the zone belongs to
        /// </summary>
        [JsonProperty("account")]
        public Account Account { get; set; }

        /// <summary>
        /// A full zone implies that DNS is hosted with CloudFlare. A partial zone is typically a partner-hosted zone or a CNAME setup.
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ZoneType Type { get; set; }

        /// <summary>
        /// Whether you want automatically attempt to fetch existing DNS records
        /// </summary>
        [JsonProperty("jump_start")]
        public bool JumpStart { get; set; }
    }
}
