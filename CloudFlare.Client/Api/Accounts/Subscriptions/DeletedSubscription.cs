using Newtonsoft.Json;

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
        [JsonProperty("subscription_id")]
        public string SubscriptionId { get; set; }
    }
}
