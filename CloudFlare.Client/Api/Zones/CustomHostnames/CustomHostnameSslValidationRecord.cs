using System.Collections.Generic;
using Newtonsoft.Json;

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
        [JsonProperty("txt_name")]
        public string TxtName { get; set; }

        /// <summary>
        /// TxtValue
        /// </summary>
        [JsonProperty("txt_value")]
        public string TxtValue { get; set; }

        /// <summary>
        /// HttpUrl
        /// </summary>
        [JsonProperty("http_url")]
        public string HttpUrl { get; set; }

        /// <summary>
        /// HttpBody
        /// </summary>
        [JsonProperty("http_body")]
        public string HttpBody { get; set; }

        /// <summary>
        /// Emails
        /// </summary>
        [JsonProperty("emails")]
        public IReadOnlyList<string> Emails { get; set; }
    }
}
