using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Represents the custom hostname types
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum CustomHostnameOrderType
{
    /// <summary>
    /// SSL
    /// </summary>
    [EnumMember(Value = "ssl")]
    Ssl,

    /// <summary>
    /// SSL Status
    /// </summary>
    [EnumMember(Value = "ssl_status")]
    SslStatus
}
