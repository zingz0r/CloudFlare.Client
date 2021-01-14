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
        AccountName,

        Status
    }
}