using System;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    /// <summary>
    /// SslCertificate
    /// </summary>
    public class SslCertificate
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// IssuedOn
        /// </summary>
        [JsonProperty("issued_on")]
        public DateTime? IssuedOn { get; set; }

        /// <summary>
        /// ExpiresOn
        /// </summary>
        [JsonProperty("expires_on")]
        public DateTime? ExpiresOn { get; set; }

        /// <summary>
        /// UploadedOn
        /// </summary>
        [JsonProperty("uploaded_on")]
        public DateTime? UploadedOn { get; set; }

        /// <summary>
        /// Issuer
        /// </summary>
        [JsonProperty("issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// SerialNumber
        /// </summary>
        [JsonProperty("serial_number")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Signature
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// FingerprintSha256
        /// </summary>
        [JsonProperty("fingerprint_sha256")]
        public string FingerprintSha256 { get; set; }
    }
}
