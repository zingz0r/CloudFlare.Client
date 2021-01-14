using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the component value types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ComponentValueType
    {
        [EnumMember(Value = "page_rules")]
        PageRules
    }
}