using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the method types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MethodType
    {
        [JsonProperty("http")]
        Http,

        [JsonProperty("email")]
        Email,

        [JsonProperty("cname")]
        Cname
    }
}