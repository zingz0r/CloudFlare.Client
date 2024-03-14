using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Zones.DnsRecord
{
    /// <summary>
    /// Dns record import
    /// </summary>
    public class DnsRecordImport
    {
        /// <summary>
        /// Number of the imported records
        /// </summary>
        [JsonPropertyName("recs_added")]
        public int RecordsAdded { get; set; }

        /// <summary>
        /// Number of total parsed records
        /// </summary>
        [JsonPropertyName("total_records_parsed")]
        public int TotalRecordsParsed { get; set; }
    }
}
