using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Represents the regions
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum Region
{
    /// <summary>
    /// World
    /// </summary>
    [EnumMember(Value = "world")]
    World
}
