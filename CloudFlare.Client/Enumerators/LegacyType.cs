using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{

    /// <summary>
    /// Represents the legacy type
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LegacyType
    {
        [EnumMember(Value = "business")]
        Business, 

        [EnumMember(Value = "enterprise")]
        Enterprise,

        [EnumMember(Value = "free")]
        Free,

        [EnumMember(Value = "pro")]
        Pro
    }
}
