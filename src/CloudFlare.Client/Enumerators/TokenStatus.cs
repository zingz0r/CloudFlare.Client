using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Represents the zone statuses
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum TokenStatus
{
    /// <summary>
    /// Active
    /// </summary>
    [EnumMember(Value = "active")]
    Active,

    /// <summary>
    /// Disabled
    /// </summary>
    [EnumMember(Value = "disabled")]
    Disabled,

    /// <summary>
    /// Expired
    /// </summary>
    [EnumMember(Value = "expired")]
    Expired
}
