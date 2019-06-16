using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the state that the subscription is in
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SubscriptionState
    {
        [EnumMember(Value = "Trial")]
        Trial,

        [EnumMember(Value = "Provisioned")]
        Provisioned,

        [EnumMember(Value = "Paid")]
        Paid,

        [EnumMember(Value = "AwaitingPayment")]
        AwaitingPayment,

        [EnumMember(Value = "Cancelled")]
        Cancelled,

        [EnumMember(Value = "Failed")]
        Failed,

        [EnumMember(Value = "Expired")]
        Expired
    }
}