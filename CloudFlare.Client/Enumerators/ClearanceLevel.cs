using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the clearance levels
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ClearanceLevel
    {
        /// <summary>
        /// No Clearance
        /// </summary>
        [EnumMember(Value = "no_clearance")]
        NoClearance,

        /// <summary>
        /// JS Challenge
        /// </summary>
        [EnumMember(Value = "jschallenge")]
        JsChallenge,

        /// <summary>
        /// Managed
        /// </summary>
        [EnumMember(Value = "managed")]
        Managed,

        /// <summary>
        /// Interactive
        /// </summary>
        [EnumMember(Value = "interactive")]
        Interactive
    }
}
