using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Status of this membership
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status
    {
        [EnumMember(Value = "accepted")]
        Accepted,
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "rejected")]
        Rejected
    }
}
