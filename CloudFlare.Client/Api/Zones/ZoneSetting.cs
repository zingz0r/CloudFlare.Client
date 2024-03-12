using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Api.Zones
{
    /// <summary>
    /// Represents the SSL setting response.
    /// </summary>
    public class ZoneSetting<T>
    {
        /// <summary>
        /// The ID of the setting.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The value of the setting.
        /// </summary>
        [JsonPropertyName("value")]
        public T Value { get; set; }

        /// <summary>
        /// The last time this setting was modified.
        /// </summary>
        [JsonPropertyName("modified_on")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// The status of the certificate.
        /// </summary>
        [JsonPropertyName("certificate_status")]
        public string CertificateStatus { get; set; }

        /// <summary>
        /// Any validation errors related to the SSL certificate.
        /// </summary>
        [JsonPropertyName("validation_errors")]
        public IReadOnlyList<ErrorDetails> ValidationErrors { get; set; }

        /// <summary>
        /// Indicates whether this setting can be modified.
        /// </summary>
        [JsonPropertyName("editable")]
        public bool Editable { get; set; }
    }
}
