using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Protocol
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
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
}
