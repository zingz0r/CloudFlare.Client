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
        /// <summary>
        /// Business
        /// </summary>
        [EnumMember(Value = "business")]
        Business,

        /// <summary>
        /// Enterprise
        /// </summary>
        [EnumMember(Value = "enterprise")]
        Enterprise,

        /// <summary>
        /// Free
        /// </summary>
        [EnumMember(Value = "free")]
        Free,

        /// <summary>
        /// Pro
        /// </summary>
        [EnumMember(Value = "pro")]
        Pro,

        /// <summary>
        /// Pro Plus
        /// </summary>
        [EnumMember(Value = "pro_plus")]
        ProPlus
    }
}
