using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the owner types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OwnerType
    {
        [EnumMember(Value = "user")]
        User,

        [EnumMember(Value = "organization")]
        Organization
    }
}
