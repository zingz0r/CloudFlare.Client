using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents domain validation types
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum DomainValidationType
    {
        /// <summary>
        /// DV type
        /// </summary>
        [EnumMember(Value = "dv")]
        Dv
    }
}
