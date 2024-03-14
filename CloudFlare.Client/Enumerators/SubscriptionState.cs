using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Enumerators
{
    /// <summary>
    /// Represents the state that the subscription is in
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum SubscriptionState
    {
        /// <summary>
        /// Trial
        /// </summary>
        [EnumMember(Value = "Trial")]
        Trial,

        /// <summary>
        /// Provisioned
        /// </summary>
        [EnumMember(Value = "Provisioned")]
        Provisioned,

        /// <summary>
        /// Paid
        /// </summary>
        [EnumMember(Value = "Paid")]
        Paid,

        /// <summary>
        /// Awaiting payment
        /// </summary>
        [EnumMember(Value = "AwaitingPayment")]
        AwaitingPayment,

        /// <summary>
        /// Cancelled
        /// </summary>
        [EnumMember(Value = "Cancelled")]
        Cancelled,

        /// <summary>
        /// Failed
        /// </summary>
        [EnumMember(Value = "Failed")]
        Failed,

        /// <summary>
        /// Expired
        /// </summary>
        [EnumMember(Value = "Expired")]
        Expired
    }
}
