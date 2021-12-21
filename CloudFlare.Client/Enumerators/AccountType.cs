using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the account types
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AccountType
    {
        /// <summary>
        /// Standard
        /// </summary>
        [EnumMember(Value = "standard")]
        Standard
    }
}
