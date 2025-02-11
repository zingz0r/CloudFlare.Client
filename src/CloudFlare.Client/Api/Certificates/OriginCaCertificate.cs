using System;
using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Certificates;

/// <summary>
/// Certificate
/// </summary>
public class OriginCaCertificate
{
    /// <summary>
    /// Unique identifier for the certificate.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
    
    /// <summary>
    /// The Origin CA certificate. Will be newline-encoded.
    /// </summary>
    [JsonProperty("certificate")]
    public string Certificate { get; set; }

    /// <summary>
    /// List of hostnames or wildcard names (e.g., *.example.com) bound to the certificate.
    /// </summary>
    [JsonProperty("hostnames")]
    public IReadOnlyList<string> Hostnames { get; set; }
    
    /// <summary>
    /// When the certificate will expire.
    /// </summary>
    [JsonProperty("expires_on")]
    [JsonConverter(typeof(DateTimeConverter), Constants.DateTimeFormat.CertificatesExpiresOn, true )]
    public DateTime? ExpiresOn { get; set; }

    /// <summary>
    /// Signature type desired on certificate.
    /// </summary>
    [JsonProperty("request_type")]
    public CertificateRequestType RequestType { get; set; }

    /// <summary>
    /// The number of days for which the certificate should be valid.
    /// </summary>
    [JsonProperty("requested_validity")]
    public int RequestedValidity { get; set; }
    
    /// <summary>
    /// The Certificate Signing Request (CSR). Must be newline-encoded.
    /// </summary>
    [JsonProperty("csr")]
    public string Csr { get; set; }
}
