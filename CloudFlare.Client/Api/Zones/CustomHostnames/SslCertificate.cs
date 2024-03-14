using System;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    /// <summary>
    /// SslCertificate
    /// </summary>
    public class SslCertificate
    {
        /// <summary>
        /// Custom hostname SSL identifier tag
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The time on which the custom certificate was created
        /// </summary>
        [JsonPropertyName("issued_on")]
        public DateTime? IssuedOn { get; set; }

        /// <summary>
        /// The time the custom certificate expires on
        /// </summary>
        [JsonPropertyName("expires_on")]
        public DateTime? ExpiresOn { get; set; }

        /// <summary>
        /// The time the custom certificate was uploaded
        /// </summary>
        [JsonPropertyName("uploaded_on")]
        public DateTime? UploadedOn { get; set; }

        /// <summary>
        /// The issuer on a custom uploaded certificate
        /// </summary>
        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// The serial number on a custom uploaded certificate
        /// </summary>
        [JsonPropertyName("serial_number")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// The signature on a custom uploaded certificate
        /// </summary>
        [JsonPropertyName("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// The SHA256 fingerprint on a custom uploaded certificate
        /// </summary>
        [JsonPropertyName("fingerprint_sha256")]
        public string FingerprintSha256 { get; set; }
    }
}
