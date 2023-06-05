using System;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones
{
    /// <summary>
    /// Represents the SSL setting response.
    /// </summary>
    public class ZoneSetting
    {
        /// <summary>
        /// The ID of the SSL setting.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The value of the SSL setting.
        /// </summary>
        [JsonProperty("value")]
        public SslSetting Value { get; set; }

        /// <summary>
        /// The last time this setting was modified.
        /// </summary>
        [JsonProperty("modified_on")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// The status of the SSL certificate.
        /// </summary>
        [JsonProperty("certificate_status")]
        public string CertificateStatus { get; set; }

        /// <summary>
        /// Any validation errors related to the SSL certificate.
        /// </summary>
        [JsonProperty("validation_errors")]
        public string[] ValidationErrors { get; set; }

        /// <summary>
        /// Indicates whether this setting can be modified.
        /// </summary>
        [JsonProperty("editable")]
        public bool Editable { get; set; }
    }
}
