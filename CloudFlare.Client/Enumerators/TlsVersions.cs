using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents TLS versions
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum TlsVersion
    {
        /// <summary>
        /// TLS version 1.0
        /// </summary>
        [EnumMember(Value = "1.0")]
        Tls10,

        /// <summary>
        /// TLS version 1.1
        /// </summary>
        [EnumMember(Value = "1.1")]
        Tls11,

        /// <summary>
        /// TLS version 1.2
        /// </summary>
        [EnumMember(Value = "1.2")]
        Tls12,

        /// <summary>
        /// TLS version 1.3
        /// </summary>
        [EnumMember(Value = "1.3")]
        Tls13
    }
}
