using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the zone statuses
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ZoneStatus
    {
        [EnumMember(Value = "active")]
        Active,

        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "initializing")]
        Initializing,

        [EnumMember(Value = "moved")]
        Moved,

        [EnumMember(Value = "deleted")]
        Deleted,

        [EnumMember(Value = "deactivated")]
        Deactivated
    }
}