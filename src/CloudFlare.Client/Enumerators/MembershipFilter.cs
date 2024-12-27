using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Order memberships by
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum MembershipOrder
{
    /// <summary>
    /// Account name
    /// </summary>
    [EnumMember(Value = "account_name")]
    AccountName,

    /// <summary>
    /// Status
    /// </summary>
    [EnumMember(Value = "status")]
    Status
}
