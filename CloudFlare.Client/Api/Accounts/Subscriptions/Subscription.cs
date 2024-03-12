using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Accounts.Subscriptions
{
    /// <summary>
    /// Subscription
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// An App object
        /// </summary>
        [JsonPropertyName("app")]
        public App App { get; set; }

        /// <summary>
        /// Subscription identifier tag
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The state that the subscription is in
        /// </summary>
        [JsonPropertyName("state")]
        public SubscriptionState State { get; set; }

        /// <summary>
        /// The price of the subscription that will be billed, in US dollars
        /// </summary>
        [JsonPropertyName("price")]
        public long Price { get; set; }

        /// <summary>
        /// The monetary unit in which pricing information is displayed
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The list of add-ons subscribed to
        /// </summary>
        [JsonPropertyName("component_values")]
        public IReadOnlyList<ComponentValue> ComponentValues { get; set; }

        /// <summary>
        /// A simple zone object. May have null properties if not a zone subscription.
        /// </summary>
        [JsonPropertyName("zone")]
        public Zone Zone { get; set; }

        /// <summary>
        /// How often the subscription is renewed automatically
        /// </summary>
        [JsonPropertyName("frequency")]
        public Frequency Frequency { get; set; }

        /// <summary>
        /// The rate plan applied to the subscription
        /// </summary>
        [JsonPropertyName("rate_plan")]
        public RatePlan RatePlan { get; set; }

        /// <summary>
        /// The end of the current period, and also when the next billing is due
        /// </summary>
        [JsonPropertyName("current_period_end")]
        public DateTime? CurrentPeriodEnd { get; set; }

        /// <summary>
        /// When the current billing period started, may be the same as InitialPeriodStart if this is the first period
        /// </summary>
        [JsonPropertyName("current_period_start")]
        public DateTime CurrentPeriodStart { get; set; }
    }
}
