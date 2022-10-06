using System;
using System.Collections.Generic;
using System.Text;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones
{
    /// <summary>
    /// Optimatization/Autominify Settings
    /// </summary>
    public class MinifySetting
    {
        /// <summary>
        /// Switch for turning on/off HTML auto-minification
        /// </summary>
        [JsonProperty("html")]
        public FeatureStatus Html { get; set; }

        /// <summary>
        /// Switch for turning on/off CSS auto-minification
        /// </summary>
        [JsonProperty("css")]
        public FeatureStatus Css { get; set; }

        /// <summary>
        /// Switch for turning on/off Javascript auto-minification
        /// </summary>
        [JsonProperty("js")]
        public FeatureStatus Js { get; set; }
    }
}
