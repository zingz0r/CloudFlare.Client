using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Represents the Rate Plan Scopes
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum RatePlanScope
{
    /// <summary>
    /// Zone
    /// </summary>
    [EnumMember(Value = "zone")]
    Zone
}
