using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Accounts.Subscriptions
{
    /// <summary>
    /// Deleted subscription
    /// </summary>
    public class DeletedSubscription
    {
        /// <summary>
        /// The deleted subscription id
        /// </summary>
        [JsonPropertyName("subscription_id")]
        public string SubscriptionId { get; set; }
    }
}
