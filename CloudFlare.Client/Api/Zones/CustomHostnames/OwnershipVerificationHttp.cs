using System;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    /// <summary>
    /// Ownership verification http
    /// </summary>
    public class OwnershipVerificationHttp
    {
        /// <summary>
        /// Http uri
        /// </summary>
        [JsonPropertyName("http_url")]
        public Uri HttpUrl { get; set; }

        /// <summary>
        /// Http body
        /// </summary>
        [JsonPropertyName("http_body")]
        public Guid HttpBody { get; set; }
    }
}
