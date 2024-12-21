using System;
using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

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
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonProperty("type")]
        public DnsRecordType Type { get; set; }

        /// <summary>
        /// Name of the record
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Comment of the record
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Content of the record
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// DNS record comment
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// DNS record tags
        /// </summary>
        [JsonProperty("tags")]
        public IList<string> Tags { get; set; }

        /// <summary>
        /// Whether the proxy could be enabled for the record
        /// </summary>
        [JsonProperty("proxiable")]
        public bool Proxiable { get; set; }

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

        /// <summary>
        /// Whether a registrar lock in place for this domain
        /// </summary>
        [JsonProperty("locked")]
        public bool Locked { get; set; }

        /// <summary>
        /// Identifier of the zone
        /// </summary>
        [JsonProperty("zone_id")]
        public string ZoneId { get; set; }

        /// <summary>
        /// Name of the zone
        /// </summary>
        [JsonProperty("zone_name")]
        public string ZoneName { get; set; }

        /// <summary>
        /// Record creation date
        /// </summary>
        [JsonProperty("created_on")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Last modification date
        /// </summary>
        [JsonProperty("modified_on")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Last modification date of the comment
        /// </summary>
        [JsonProperty("comment_modified_on")]
        public DateTime? CommentModifiedDate { get; set; }

        /// <summary>
        /// Last modification date of the tags property
        /// </summary>
        [JsonProperty("tags_modified_on")]
        public DateTime? TagsModifiedDate { get; set; }

        /// <summary>
        /// Additional data
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }
    }
}
