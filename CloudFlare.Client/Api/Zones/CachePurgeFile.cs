using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones;

/// <summary>
/// Represents a file to be purged from CloudFlare's cache.
/// </summary>
public class CachePurgeFile
{
    /// <summary>
    /// The url that should be purged. Wildcards are not supported. Non-ignored query strings must be included.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    /// <summary>
    /// To purge files with custom cache keys, include the headers used to compute the cache key.
    /// If you have a device type or geo in your cache key, you will need to include the CF-Device-Type or
    /// CF-IPCountry headers.
    /// If you have lang in your cache key, you will need to include the Accept-Language header.
    /// </summary>
    [JsonProperty("headers")]
    public Dictionary<string, string> Headers { get; set; }
}
