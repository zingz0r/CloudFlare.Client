using System;
using System.Net;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Models
{
    public class DnsRecord
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DnsRecordType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("proxiable")]
        public bool Proxiable { get; set; }

        [JsonProperty("proxied")]
        public bool? Proxied { get; set; }

        [JsonProperty("priority")]
        public int? Priority { get; set; }

        [JsonProperty("ttl")]
        public int? Ttl { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("zone_id")]
        public string ZoneId { get; set; }

        [JsonProperty("zone_name")]
        public string ZoneName { get; set; }

        [JsonProperty("created_on")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modified_on")]
        public DateTime ModifiedDate { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }
}