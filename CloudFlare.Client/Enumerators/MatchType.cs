using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents how to match filters
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum MatchType
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember(Value = "all")]
        All,

        /// <summary>
        /// Any
        /// </summary>
        [EnumMember(Value = "any")]
        Any
    }
}
