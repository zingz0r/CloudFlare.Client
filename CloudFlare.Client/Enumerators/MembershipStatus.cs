using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Status of this membership
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum MembershipStatus
    {
        /// <summary>
        /// Accepted
        /// </summary>
        [EnumMember(Value = "accepted")]
        Accepted,

        /// <summary>
        /// Pending
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending,

        /// <summary>
        /// Rejected
        /// </summary>
        [EnumMember(Value = "rejected")]
        Rejected
    }
}
