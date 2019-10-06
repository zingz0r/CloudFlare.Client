using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the zone statuses
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VerifyTokenStatus
    {
        [EnumMember(Value = "active")]
        Active
    }
}
