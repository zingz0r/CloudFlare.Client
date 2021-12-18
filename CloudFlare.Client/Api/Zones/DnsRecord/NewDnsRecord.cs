using System;
using CloudFlare.Client.Api.Parameters.Data;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.DnsRecord
{
    public class NewDnsRecord : NewDnsRecordBase
    {
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
        /// DNS record type
        /// </summary>
        [JsonProperty("type")]
        public DnsRecordType Type { get; set; }
    }

    public class NewDnsRecord<T> : NewDnsRecordBase
        where T : class, IData
    {
        public NewDnsRecord()
        {
            Type = typeof(T) == typeof(Srv) ? DnsRecordType.Srv : throw new NotSupportedException($"{typeof(T)} is not supported Data type");
        }
        
        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonProperty("type")]
        public DnsRecordType Type { get; }
        
        /// <summary>
        /// Data of the record
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}