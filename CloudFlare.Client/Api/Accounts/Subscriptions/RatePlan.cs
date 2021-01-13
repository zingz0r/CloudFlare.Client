using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts.Subscriptions
{
    public class RatePlan
    {
        /// <summary>
        /// The rate plan identifier tag
        /// </summary>
        [JsonProperty("id")]
        public LegacyType Id { get; set; }

        /// <summary>
        /// The public name of the rate plan
        /// </summary>
        [JsonProperty("public_name")]
        public string PublicName { get; set; }

        /// <summary>
        /// The currency of the rate plan
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The scope of the rate plan
        /// </summary>
        [JsonProperty("scope")]
        public RatePlanScope Scope { get; set; }

        /// <summary>
        /// The sets of the rate plan
        /// </summary>
        [JsonProperty("sets")]
        public IReadOnlyList<string> Sets { get; set; }

        /// <summary>
        /// Whether the rate plan is contract
        /// </summary>
        [JsonProperty("is_contract")]
        public bool IsContract { get; set; }

        /// <summary>
        /// Whether the rate plan is externally managed
        /// </summary>
        [JsonProperty("externally_managed")]
        public bool ExternallyManaged { get; set; }
    }
}
