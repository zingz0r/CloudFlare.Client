using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Accounts.TurnstileWidgets
{
    /// <summary>
    /// Turnstile widget
    /// </summary>
    public class TurnstileWidget
    {
        /// <summary>
        /// Turnstile widget identifier tag
        /// </summary>
        [JsonPropertyName("sitekey")]
        public string Id { get; set; }

        /// <summary>
        /// Indicates if CloudFlare issues computationally expensive challenges in response to malicious bots (ENT only)
        /// </summary>
        [JsonPropertyName("bot_fight_mode")]
        public bool BotFightMode { get; set; }

        /// <summary>
        /// Indicates if turnstile is embedded on a CloudFlare site and the widget should grant challenge clearance, this setting can determine the clearance level to be set
        /// </summary>
        [JsonPropertyName("clearance_level")]
        public ClearanceLevel ClearanceLevel { get; set; }

        /// <summary>
        /// Widget creation date
        /// </summary>
        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Domains
        /// </summary>
        [JsonPropertyName("domains")]
        public IReadOnlyList<string> Domains { get; set; }

        /// <summary>
        /// Widget Mode
        /// </summary>
        [JsonPropertyName("mode")]
        public WidgetMode Mode { get; set; }

        /// <summary>
        /// Last modification date
        /// </summary>
        [JsonPropertyName("modified_on")]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Human readable widget name. Not unique. CloudFlare suggests that you set this to a meaningful string to make it easier to identify your widget, and where it is used.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether to not show any CloudFlare branding on the widget (ENT only)
        /// </summary>
        [JsonPropertyName("offlabel")]
        public bool OffLabel { get; set; }

        /// <summary>
        /// Region where this widget can be used.
        /// </summary>
        [JsonPropertyName("region")]
        public Region Region { get; set; }

        /// <summary>
        /// Secret key for this widget.
        /// </summary>
        [JsonPropertyName("secret")]
        public string Secret { get; set; }
    }
}
