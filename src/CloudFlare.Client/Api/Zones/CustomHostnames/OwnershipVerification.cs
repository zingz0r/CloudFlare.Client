using System;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames;

/// <summary>
/// Verification of the ownership
/// </summary>
public class OwnershipVerification
{
    /// <summary>
    /// Type
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    /// <summary>
    /// Nane
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Value
    /// </summary>
    [JsonProperty("value")]
    public Guid Value { get; set; }
}
