using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class DnsRecordScan
    {
        [JsonProperty("recs_added")]
        public long RecsAdded { get; set; }

        [JsonProperty("recs_added_by_type")]
        public Dictionary<string, long> RecsAddedByType { get; set; }

        [JsonProperty("total_records_parsed")]
        public long TotalRecordsParsed { get; set; }
    }
}