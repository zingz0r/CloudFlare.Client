using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the zone types
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ZoneType
    {
        /// <summary>
        /// Full
        /// </summary>
        [EnumMember(Value = "full")]
        Full,

        /// <summary>
        /// Partial
        /// </summary>
        [EnumMember(Value = "partial")]
        Partial
    }
}
