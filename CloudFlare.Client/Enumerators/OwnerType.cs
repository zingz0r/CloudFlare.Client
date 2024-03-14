using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the owner types
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum OwnerType
    {
        /// <summary>
        /// User
        /// </summary>
        [EnumMember(Value = "user")]
        User,

        /// <summary>
        /// Organization
        /// </summary>
        [EnumMember(Value = "organization")]
        Organization
    }
}
