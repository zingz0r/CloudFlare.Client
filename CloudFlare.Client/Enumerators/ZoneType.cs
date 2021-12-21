using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the zone types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
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
