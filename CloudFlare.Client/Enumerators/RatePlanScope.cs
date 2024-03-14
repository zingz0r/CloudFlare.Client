using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the Rate Plan Scopes
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum RatePlanScope
    {
        /// <summary>
        /// Zone
        /// </summary>
        [EnumMember(Value = "zone")]
        Zone
    }
}
