using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Protocol
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Protocol
    {
        [EnumMember(Value = "_tcp")]
        Tcp,
        [EnumMember(Value = "_udp")]
        Udp,
        [EnumMember(Value = "_tls")]
        Tls
    }
}
