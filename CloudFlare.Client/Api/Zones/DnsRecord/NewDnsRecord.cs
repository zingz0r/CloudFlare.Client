using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using CloudFlare.Client.Api.Parameters.Data;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;

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
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Content of the record
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }

        /// <summary>
        /// DNS record comment
        /// </summary>
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Used with some records like MX and SRV to determine priority.
        /// If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        [JsonPropertyName("priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonPropertyName("type")]
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
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Data of the record
        /// </summary>
        [JsonPropertyName("data")]
        public T Data { get; set; }

        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonPropertyName("type")]
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
