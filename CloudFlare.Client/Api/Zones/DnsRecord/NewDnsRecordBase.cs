using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.DnsRecord
{
    public abstract class NewDnsRecordBase
    {
        /// <summary>
        /// Whether the record is receiving the performance and security benefits of CloudFlare
        /// </summary>
        [JsonProperty("proxied")]
        public bool? Proxied { get; set; }

        /// <summary>
        /// Used with some records like MX and SRV to determine priority.
        /// If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        [JsonProperty("priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// Time to live (TTL) of the DNS entry for the IP address returned by this load balancer.
        /// This only applies to gray-clouded (unproxied) load balancers.
        /// </summary>
        [JsonProperty("ttl")]
        public int? Ttl { get; set; }
    }
}
