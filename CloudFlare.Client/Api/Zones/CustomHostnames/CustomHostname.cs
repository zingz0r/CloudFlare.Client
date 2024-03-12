using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    /// <summary>
    /// Custom hostname
    /// </summary>
    public class CustomHostname
    {
        /// <summary>
        /// Custom hostname identifier tag
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The custom hostname that will point to your hostname via CNAME
        /// </summary>
        [JsonPropertyName("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// SSL settings for the custom hostname
        /// </summary>
        [JsonPropertyName("ssl")]
        public Ssl Ssl { get; set; }

        /// <summary>
        /// Custom metadata
        /// </summary>
        [JsonPropertyName("custom_metadata")]
        public IReadOnlyDictionary<string, string> CustomMetadata { get; set; }

        /// <summary>
        /// Custom origin server
        /// </summary>
        [JsonPropertyName("custom_origin_server")]
        public string CustomOriginServer { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public CustomHostnameStatus Status { get; set; }

        /// <summary>
        /// Verification errors
        /// </summary>
        [JsonPropertyName("verification_errors")]
        public IReadOnlyList<string> VerificationErrors { get; set; }

        /// <summary>
        /// Ownership verification
        /// </summary>
        [JsonPropertyName("ownership_verification")]
        public OwnershipVerification OwnershipVerification { get; set; }

        /// <summary>
        /// Ownership http verification
        /// </summary>
        [JsonPropertyName("ownership_verification_http")]
        public OwnershipVerificationHttp OwnershipVerificationHttp { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
