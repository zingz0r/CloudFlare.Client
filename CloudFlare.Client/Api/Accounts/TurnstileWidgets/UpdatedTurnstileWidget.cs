using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts.TurnstileWidgets
{
    /// <summary>
    /// Updated Turnstile Widget
    /// </summary>
    internal class UpdatedTurnstileWidget
    {
        /// <summary>
        /// Indicates if CloudFlare issues computationally expensive challenges in response to malicious bots (ENT only)
        /// </summary>
        [JsonProperty("bot_fight_mode")]
        public bool BotFightMode { get; set; }

        /// <summary>
        /// Indicates if turnstile is embedded on a CloudFlare site and the widget should grant challenge clearance, this setting can determine the clearance level to be set
        /// </summary>
        [JsonProperty("clearance_level")]
        public ClearanceLevel ClearanceLevel { get; set; }

        /// <summary>
        /// Domains
        /// </summary>
        [JsonProperty("domains")]
        public IReadOnlyList<string> Domains { get; set; }

        /// <summary>
        /// Widget Mode
        /// </summary>
        [JsonProperty("mode")]
        public WidgetMode Mode { get; set; }

        /// <summary>
        /// Human readable widget name. Not unique. CloudFlare suggests that you set this to a meaningful string to make it easier to identify your widget, and where it is used.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether to not show any CloudFlare branding on the widget (ENT only)
        /// </summary>
        [JsonProperty("offlabel")]
        public bool OffLabel { get; set; }
    }
}
