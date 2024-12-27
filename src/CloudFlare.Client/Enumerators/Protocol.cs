using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Protocol
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum Protocol
{
    /// <summary>
    /// TCP
    /// </summary>
    [EnumMember(Value = "_tcp")]
    Tcp,

    /// <summary>
    /// UDP
    /// </summary>
    [EnumMember(Value = "_udp")]
    Udp,

    /// <summary>
    /// TLS
    /// </summary>
    [EnumMember(Value = "_tls")]
    Tls
}
