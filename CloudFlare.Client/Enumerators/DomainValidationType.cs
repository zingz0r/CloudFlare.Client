using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents domain validation types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DomainValidationType
    {
        [EnumMember(Value = "dv")]
        Dv
    }
}
