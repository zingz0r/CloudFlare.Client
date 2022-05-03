using System;
using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.Filters;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.FirewallRules
{
    /// <summary>
    /// Firewall Rule
    /// </summary>
    public class FirewallRule
    {
        /// <summary>
        /// Firewall Rule identifier
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The action to apply to a matched request. Note that action "log" is only available for enterprise customers.
        /// valid values: block,challenge,js_challenge,allow,log,bypass
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }

        /// <summary>
        /// Filter
        /// </summary>
        [JsonProperty("filter")]
        public Filter Filter { get; set; }

        /// <summary>
        /// List of products to bypass for a request when the bypass action is used.
        /// </summary>
        [JsonProperty("products")]
        public IEnumerable<string> Products { get; set; }

        /// <summary>
        /// The priority of the rule to allow control of processing order. A lower number indicates high priority. If not provided, any rules with a priority will be sequenced before those without.
        /// </summary>
        [JsonProperty("priority")]
        public string Priority { get; set; }

        /// <summary>
        /// Whether this firewall rule is currently paused.
        /// </summary>
        [JsonProperty("paused")]
        public bool Paused { get; set; }

        /// <summary>
        /// A description of the rule to help identify it.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Short reference tag to quickly select related rules.
        /// </summary>
        [JsonProperty("ref")]
        public string Reference { get; set; }

        /// <summary>
        /// Created On
        /// </summary>
        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Modified on
        /// </summary>
        [JsonProperty("modified_on")]
        public DateTime ModifiedOn { get; set; }
    }
}
