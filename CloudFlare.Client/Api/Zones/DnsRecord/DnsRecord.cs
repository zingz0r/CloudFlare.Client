using System;
using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones.DnsRecord
{
    /// <summary>
    /// Dns record
    /// </summary>
    public class DnsRecord
    {
        /// <summary>
        /// DNS record identifier
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonPropertyName("type")]
        public DnsRecordType Type { get; set; }

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
        /// Whether the proxy could be enabled for the record
        /// </summary>
        [JsonPropertyName("proxiable")]
        public bool Proxiable { get; set; }

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

        /// <summary>
        /// Time to live (TTL) of the DNS entry for the IP address returned by this load balancer.
        /// This only applies to gray-clouded (unproxied) load balancers.
        /// </summary>
        [JsonPropertyName("ttl")]
        public int? Ttl { get; set; }

        /// <summary>
        /// Whether a registrar lock in place for this domain
        /// </summary>
        [JsonPropertyName("locked")]
        public bool Locked { get; set; }

        /// <summary>
        /// Identifier of the zone
        /// </summary>
        [JsonPropertyName("zone_id")]
        public string ZoneId { get; set; }

        /// <summary>
        /// Name of the zone
        /// </summary>
        [JsonPropertyName("zone_name")]
        public string ZoneName { get; set; }

        /// <summary>
        /// Record creation date
        /// </summary>
        [JsonPropertyName("created_on")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Last modification date
        /// </summary>
        [JsonPropertyName("modified_on")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Additional data
        /// </summary>
        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}
