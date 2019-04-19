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
        [EnumMember(Value = "full")]
        Full,

        [EnumMember(Value = "partial")]
        Partial
    }
}