using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the custom hostname types
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
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
}
