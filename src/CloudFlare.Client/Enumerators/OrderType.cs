using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Represents the order direction
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum OrderType
{
    /// <summary>
    /// Ascending
    /// </summary>
    [EnumMember(Value = "asc")]
    Asc,

    /// <summary>
    /// Descending
    /// </summary>
    [EnumMember(Value = "desc")]
    Desc
}
