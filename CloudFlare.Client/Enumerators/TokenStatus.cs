using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the zone statuses
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TokenStatus
    {
        [EnumMember(Value = "active")]
        Active,
        [EnumMember(Value = "disabled")]
        Disabled,
        [EnumMember(Value = "expired")]
        Expired
    }
}
