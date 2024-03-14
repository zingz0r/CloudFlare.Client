﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Api.Zones.Filters;

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
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The action to apply to a matched request. Note that action "log" is only available for enterprise customers.
        /// valid values: block,challenge,js_challenge,allow,log,bypass
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }

        /// <summary>
        /// Filter
        /// </summary>
        [JsonPropertyName("filter")]
        public Filter Filter { get; set; }

        /// <summary>
        /// List of products to bypass for a request when the bypass action is used.
        /// </summary>
        [JsonPropertyName("products")]
        public IEnumerable<string> Products { get; set; }

        /// <summary>
        /// The priority of the rule to allow control of processing order. A lower number indicates high priority. If not provided, any rules with a priority will be sequenced before those without.
        /// </summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// Whether this firewall rule is currently paused.
        /// </summary>
        [JsonPropertyName("paused")]
        public bool Paused { get; set; }

        /// <summary>
        /// A description of the rule to help identify it.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Short reference tag to quickly select related rules.
        /// </summary>
        [JsonPropertyName("ref")]
        public string Reference { get; set; }

        /// <summary>
        /// Created On
        /// </summary>
        [JsonPropertyName("created_on")]
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Modified on
        /// </summary>
        [JsonPropertyName("modified_on")]
        public DateTime? ModifiedOn { get; set; }
    }
}
