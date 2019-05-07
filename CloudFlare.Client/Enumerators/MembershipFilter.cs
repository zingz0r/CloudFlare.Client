using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Order memberships by
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MembershipOrder
    {
        [EnumMember(Value = "id")]
        Id,
        [EnumMember(Value = "account.name")]
        AccountName,
        [EnumMember(Value = "status")]
        Status
    }
}