using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.DnsRecord
{
    /// <summary>
    /// Modified DNS record
    /// </summary>
    public class ModifiedDnsRecord
    {
        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonProperty("type")]
        public DnsRecordType? Type { get; set; }

        /// <summary>
        /// Name of the record
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Content of the record
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Time to live for DNS record. Value of 1 is 'automatic'
        /// </summary>
        [JsonProperty("ttl")]
        public int? Ttl { get; set; }

        /// <summary>
        /// Whether the record is receiving the performance and security benefits of CloudFlare
        /// </summary>
        [JsonProperty("proxied")]
        public bool? Proxied { get; set; }
    }
}
