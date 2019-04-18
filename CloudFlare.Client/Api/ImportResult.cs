using Newtonsoft.Json;

namespace CloudFlare.Client.Api
{
    public class ImportResult
    {
        [JsonProperty("recs_added")]
        public int RecordsAdded { get; set; }

        [JsonProperty("total_records_parsed")]
        public int TotalRecordsParsed { get; set; }
    }
}
