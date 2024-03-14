using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones.DnsRecord
{
    /// <summary>
    /// New DNS record
    /// </summary>
    public abstract class NewDnsRecordBase
    {
        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonPropertyName("type")]
        public DnsRecordType Type { get; set; }

        /// <summary>
        /// Whether the record is receiving the performance and security benefits of CloudFlare
        /// </summary>
        [JsonPropertyName("proxied")]
        public bool? Proxied { get; set; }

        /// <summary>
        /// Time to live (TTL) of the DNS entry for the IP address returned by this load balancer.
        /// This only applies to gray-clouded (unproxied) load balancers.
        /// </summary>
        [JsonPropertyName("ttl")]
        public int? Ttl { get; set; }
    }
}
