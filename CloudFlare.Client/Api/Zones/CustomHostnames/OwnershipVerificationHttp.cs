using System;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames;

/// <summary>
/// Ownership verification http
/// </summary>
public class OwnershipVerificationHttp
{
    /// <summary>
    /// Http uri
    /// </summary>
    [JsonProperty("http_url")]
    public Uri HttpUrl { get; set; }

    /// <summary>
    /// Http body
    /// </summary>
    [JsonProperty("http_body")]
    public Guid HttpBody { get; set; }
}