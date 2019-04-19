using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Result
{
    public class DnsImportResult
    {
        /// <summary>
        /// Number of the imported records
        /// </summary>
        [JsonProperty("recs_added")]
        public int RecordsAdded { get; set; }

        /// <summary>
        /// Number of total parsed records
        /// </summary>
        [JsonProperty("total_records_parsed")]
        public int TotalRecordsParsed { get; set; }
    }
}
