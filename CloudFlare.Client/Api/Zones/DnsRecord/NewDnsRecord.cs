using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CloudFlare.Client.Api.Parameters.Data;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.DnsRecord
{
    /// <summary>
    /// New DNS record
    /// </summary>
    public class NewDnsRecord : NewDnsRecordBase
    {
        /// <summary>
        /// Name of the record
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// DNS record comment
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// DNS record tags
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Tags { get; set; }

        /// <summary>
        /// Content of the record
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Used with some records like MX and SRV to determine priority.
        /// If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        [JsonProperty("priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonProperty("type")]
        public new DnsRecordType Type
        {
            get
            {
                return base.Type;
            }

            set
            {
                value.EnsureIsNotDataType();
                base.Type = value;
            }
        }
    }

    /// <summary>
    /// New DNS record
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleType", Justification = "Reviewed.")]
    public class NewDnsRecord<T> : NewDnsRecordBase
        where T : class, IData
    {
        /// <summary>
        /// Name of the record
        /// <para>
        /// The name of the record is not mandatory for every new
        /// dns record that includes data.
        /// </para>
        /// <para>
        /// So far, only TlsA record needs a name, and Srv does not
        /// (srv's record name is in the data object).
        /// </para>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Data of the record
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }

        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonProperty("type")]
        public new DnsRecordType Type
        {
            get
            {
                return base.Type;
            }

            set
            {
                value.EnsureIsDataType();
                base.Type = value;
            }
        }
    }
}
