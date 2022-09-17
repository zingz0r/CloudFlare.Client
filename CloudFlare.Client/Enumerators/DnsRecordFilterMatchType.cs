using System.Runtime.Serialization;
using CloudFlare.Client.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents how to match filters
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DnsRecordFilterMatchType
    {
        /// <summary>
        /// All
        /// </summary>
        [EnumMember(Value = "all")]
        All,

        /// <summary>
        /// Any
        /// </summary>
        [EnumMember(Value = "any")]
        Any
    }
}
