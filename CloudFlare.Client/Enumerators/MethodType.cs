using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the method types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MethodType
    {
        [EnumMember(Value = "http")]
        Http,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "cname")]
        Cname
    }
}
