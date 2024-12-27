using System;
using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames;

/// <summary>
/// Custom hostname
/// </summary>
public class CustomHostname
{
    /// <summary>
    /// Custom hostname identifier tag
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// The custom hostname that will point to your hostname via CNAME
    /// </summary>
    [JsonProperty("hostname")]
    public string Hostname { get; set; }

    /// <summary>
    /// SSL settings for the custom hostname
    /// </summary>
    [JsonProperty("ssl")]
    public Ssl Ssl { get; set; }

    /// <summary>
    /// Custom metadata
    /// </summary>
    [JsonProperty("custom_metadata")]
    public IReadOnlyDictionary<string, string> CustomMetadata { get; set; }

    /// <summary>
    /// Custom origin server
    /// </summary>
    [JsonProperty("custom_origin_server")]
    public string CustomOriginServer { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    [JsonProperty("status")]
    public CustomHostnameStatus Status { get; set; }

    /// <summary>
    /// Verification errors
    /// </summary>
    [JsonProperty("verification_errors")]
    public IReadOnlyList<string> VerificationErrors { get; set; }

    /// <summary>
    /// Ownership verification
    /// </summary>
    [JsonProperty("ownership_verification")]
    public OwnershipVerification OwnershipVerification { get; set; }

    /// <summary>
    /// Ownership http verification
    /// </summary>
    [JsonProperty("ownership_verification_http")]
    public OwnershipVerificationHttp OwnershipVerificationHttp { get; set; }

    /// <summary>
    /// Creation date
    /// </summary>
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }
}
