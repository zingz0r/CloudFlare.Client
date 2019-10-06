using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the frequency types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Frequency
    {
        [EnumMember(Value = "weekly")]
        Weekly,

        [EnumMember(Value = "monthly")]
        Monthly,

        [EnumMember(Value = "quarterly")]
        Quarterly,

        [EnumMember(Value = "yearly")]
        Yearly
    }
}