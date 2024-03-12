using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the component value types
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum ComponentValueType
    {
        /// <summary>
        /// Page rules
        /// </summary>
        [EnumMember(Value = "page_rules")]
        PageRules
    }
}
