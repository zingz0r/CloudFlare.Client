using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Order memberships by
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum MembershipOrder
    {
        /// <summary>
        /// Account name
        /// </summary>
        [EnumMember(Value = "account_name")]
        AccountName,

        /// <summary>
        /// Status
        /// </summary>
        [EnumMember(Value = "status")]
        Status
    }
}
