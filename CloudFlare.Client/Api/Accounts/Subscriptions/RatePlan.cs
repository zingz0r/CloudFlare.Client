using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Accounts.Subscriptions
{
    /// <summary>
    /// Rate plan
    /// </summary>
    public class RatePlan
    {
        /// <summary>
        /// The rate plan identifier tag
        /// </summary>
        [JsonPropertyName("id")]
        public LegacyType Id { get; set; }

        /// <summary>
        /// The public name of the rate plan
        /// </summary>
        [JsonPropertyName("public_name")]
        public string PublicName { get; set; }

        /// <summary>
        /// The currency of the rate plan
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The scope of the rate plan
        /// </summary>
        [JsonPropertyName("scope")]
        public RatePlanScope Scope { get; set; }

        /// <summary>
        /// The sets of the rate plan
        /// </summary>
        [JsonPropertyName("sets")]
        public IReadOnlyList<string> Sets { get; set; }

        /// <summary>
        /// Whether the rate plan is contract
        /// </summary>
        [JsonPropertyName("is_contract")]
        public bool IsContract { get; set; }

        /// <summary>
        /// Whether the rate plan is externally managed
        /// </summary>
        [JsonPropertyName("externally_managed")]
        public bool ExternallyManaged { get; set; }
    }
}
