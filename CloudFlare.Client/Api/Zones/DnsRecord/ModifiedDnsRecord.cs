using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

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
        [JsonPropertyName("type")]
        public DnsRecordType? Type { get; set; }

        /// <summary>
        /// Name of the record
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Content of the record
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// Time to live for DNS record. Value of 1 is 'automatic'
        /// </summary>
        [JsonPropertyName("ttl")]
        public int? Ttl { get; set; }

        /// <summary>
        /// Whether the record is receiving the performance and security benefits of CloudFlare
        /// </summary>
        [JsonPropertyName("proxied")]
        public bool? Proxied { get; set; }

        /// <summary>
        /// Used with some records like MX and SRV to determine priority.
        /// If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        [JsonPropertyName("priority")]
        public int? Priority { get; set; }
    }
}
