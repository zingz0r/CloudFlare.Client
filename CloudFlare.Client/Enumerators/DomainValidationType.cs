using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents domain validation types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DomainValidationType
    {
        [JsonProperty("dv")]
        Dv
    }
}