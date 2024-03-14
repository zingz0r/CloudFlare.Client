using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the account types
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum AccountType
    {
        /// <summary>
        /// Standard
        /// </summary>
        [EnumMember(Value = "standard")]
        Standard,

        /// <summary>
        /// Enterprise
        /// </summary>
        [EnumMember(Value = "enterprise")]
        Enterprise
    }
}
