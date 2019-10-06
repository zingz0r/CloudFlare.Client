using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents possible feature statuses
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FeatureStatus
    {
        [JsonProperty("on")]
        On,

        [JsonProperty("off")]
        Off
    }
}