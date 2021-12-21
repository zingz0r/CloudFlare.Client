using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the frequency types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Frequency
    {
        /// <summary>
        /// Weekly frequency
        /// </summary>
        [EnumMember(Value = "weekly")]
        Weekly,

        /// <summary>
        /// Monthly frequency
        /// </summary>
        [EnumMember(Value = "monthly")]
        Monthly,

        /// <summary>
        /// Quarterly frequency
        /// </summary>
        [EnumMember(Value = "quarterly")]
        Quarterly,

        /// <summary>
        /// Yearly frequency
        /// </summary>
        [EnumMember(Value = "yearly")]
        Yearly
    }
}
