using System;
using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class AccountSubscription
    {
        /// <summary>
        /// An App object
        /// </summary>
        [JsonProperty("app")]
        public App App { get; set; }

        /// <summary>
        /// Subscription identifier tag
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The state that the subscription is in
        /// </summary>
        [JsonProperty("state")]
        public SubscriptionState State { get; set; }

        /// <summary>
        /// The price of the subscription that will be billed, in US dollars
        /// </summary>
        [JsonProperty("price")]
        public long Price { get; set; }

        /// <summary>
        /// The monetary unit in which pricing information is displayed
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The list of add-ons subscribed to
        /// </summary>
        [JsonProperty("component_values")]
        public IEnumerable<ComponentValue> ComponentValues { get; set; }

        /// <summary>
        /// A simple zone object. May have null properties if not a zone subscription.
        /// </summary>
        [JsonProperty("zone")]
        public Zone Zone { get; set; }

        /// <summary>
        /// How often the subscription is renewed automatically
        /// </summary>
        [JsonProperty("frequency")]
        public Frequency Frequency { get; set; }

        /// <summary>
        /// The rate plan applied to the subscription
        /// </summary>
        [JsonProperty("rate_plan")]
        public RatePlan RatePlan { get; set; }

        /// <summary>
        /// The end of the current period, and also when the next billing is due
        /// </summary>
        [JsonProperty("current_period_end")]
        public DateTime CurrentPeriodEnd { get; set; }

        /// <summary>
        /// When the current billing period started, may be the same as InitialPeriodStart if this is the first period
        /// </summary>
        [JsonProperty("current_period_start")]
        public DateTime CurrentPeriodStart { get; set; }
    }
}