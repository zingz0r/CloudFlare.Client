using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the order direction
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum OrderType
    {
        /// <summary>
        /// Ascending
        /// </summary>
        [EnumMember(Value = "asc")]
        Asc,

        /// <summary>
        /// Descending
        /// </summary>
        [EnumMember(Value = "desc")]
        Desc
    }
}
