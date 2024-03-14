using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the legacy type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
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
        Pro
    }
}
