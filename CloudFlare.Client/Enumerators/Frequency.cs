using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the frequency types
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
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
