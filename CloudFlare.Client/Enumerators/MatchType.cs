using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents how to match filters
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
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
