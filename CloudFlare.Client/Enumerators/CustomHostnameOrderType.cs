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
        [JsonProperty("ssl")]
        Ssl,

        [JsonProperty("ssl_status")]
        SslStatus
    }
}
