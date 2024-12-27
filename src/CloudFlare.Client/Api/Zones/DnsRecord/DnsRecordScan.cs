using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.DnsRecord;

/// <summary>
/// DNS record scan
/// </summary>
public class DnsRecordScan
{
    /// <summary>
    /// Records added
    /// </summary>
    [JsonProperty("recs_added")]
    public long RecordsAdded { get; set; }

    /// <summary>
    /// Records added by type
    /// </summary>
    [JsonProperty("recs_added_by_type")]
    public IReadOnlyDictionary<string, long> RecordsAddedByType { get; set; }

    /// <summary>
    /// Total records parsed
    /// </summary>
    [JsonProperty("total_records_parsed")]
    public long TotalRecordsParsed { get; set; }
}
