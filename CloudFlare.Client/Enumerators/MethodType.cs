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
        /// <summary>
        /// Http
        /// </summary>
        [EnumMember(Value = "http")]
        Http,

        /// <summary>
        /// Email
        /// </summary>
        [EnumMember(Value = "email")]
        Email,

        /// <summary>
        /// CNAME
        /// </summary>
        [EnumMember(Value = "cname")]
        Cname,

        /// <summary>
        /// TXT
        /// </summary>
        [EnumMember(Value = "txt")]
        Txt
    }
}
