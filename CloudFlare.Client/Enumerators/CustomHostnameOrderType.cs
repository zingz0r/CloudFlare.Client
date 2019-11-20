using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the custom hostname types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CustomHostnameOrderType
    {
        [EnumMember(Value = "ssl")]
        Ssl,

        [EnumMember(Value = "ssl_status")]
        SslStatus
    }
}
