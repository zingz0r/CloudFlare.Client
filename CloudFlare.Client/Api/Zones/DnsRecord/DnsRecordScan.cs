using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.DnsRecord
{
    public class DnsRecordScan
    {
        [JsonProperty("recs_added")]
        public long RecordsAdded { get; set; }

        [JsonProperty("recs_added_by_type")]
        public IReadOnlyDictionary<string, long> RecordsAddedByType { get; set; }

        [JsonProperty("total_records_parsed")]
        public long TotalRecordsParsed { get; set; }
    }
}