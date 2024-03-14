﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    /// <summary>
    /// Control validation records
    /// </summary>
    public class CustomHostnameSslValidationRecord
    {
        /// <summary>
        /// TxtName
        /// </summary>
        [JsonPropertyName("txt_name")]
        public string TxtName { get; set; }

        /// <summary>
        /// TxtValue
        /// </summary>
        [JsonPropertyName("txt_value")]
        public string TxtValue { get; set; }

        /// <summary>
        /// HttpUrl
        /// </summary>
        [JsonPropertyName("http_url")]
        public string HttpUrl { get; set; }

        /// <summary>
        /// HttpBody
        /// </summary>
        [JsonPropertyName("http_body")]
        public string HttpBody { get; set; }

        /// <summary>
        /// Emails
        /// </summary>
        [JsonPropertyName("emails")]
        public IReadOnlyList<string> Emails { get; set; }
    }
}
