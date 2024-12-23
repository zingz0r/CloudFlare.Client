using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Represents the owner types
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum OwnerType
{
    /// <summary>
    /// User
    /// </summary>
    [EnumMember(Value = "user")]
    User,

    /// <summary>
    /// Organization
    /// </summary>
    [EnumMember(Value = "organization")]
    Organization
}
