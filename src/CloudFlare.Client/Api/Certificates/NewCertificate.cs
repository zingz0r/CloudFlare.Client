using System;
using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Certificates
{
    /// <summary>
    /// Certificate
    /// </summary>
    public class NewCertificate
    {
        /// <summary>
        /// The Certificate Signing Request (CSR). Must be newline-encoded.
        /// </summary>
        [JsonProperty("csr")]
        public string CertificateSigningRequest { get; set; }

        /// <summary>
        /// List of hostnames or wildcard names (e.g., *.example.com) bound to the certificate.
        /// </summary>
        [JsonProperty("hostnames")]
        public IReadOnlyList<string> Hostnames { get; set; }

        /// <summary>
        /// Signature type desired on certificate.
        /// </summary>
        [JsonProperty("request_type")]
        public CertificateType RequestType { get; set; }

        /// <summary>
        /// The number of days for which the certificate should be valid.
        /// </summary>
        [JsonProperty("requested_validity")]
        public int? RequestedValidity { get; set; }
    }
}
