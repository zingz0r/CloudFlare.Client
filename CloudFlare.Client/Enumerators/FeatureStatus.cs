using System.Runtime.Serialization;
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
        [EnumMember(Value = "on")]
        On,

        [EnumMember(Value = "off")]
        Off
    }
}
