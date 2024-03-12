using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the regions
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum Region
    {
        /// <summary>
        /// World
        /// </summary>
        [EnumMember(Value = "world")]
        World
    }
}
