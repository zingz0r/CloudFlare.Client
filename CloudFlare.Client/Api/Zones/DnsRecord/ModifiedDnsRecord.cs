using System.Collections.Generic;
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
        /// DNS record comment
        /// </summary>
        [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }

        /// <summary>
        /// DNS record tags
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Tags { get; set; }

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

        /// <summary>
        /// Used with some records like MX and SRV to determine priority.
        /// If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        [JsonProperty("priority")]
        public int? Priority { get; set; }
    }
}
