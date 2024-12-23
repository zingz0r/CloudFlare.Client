using System;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames;

/// <summary>
/// SslCertificate
/// </summary>
public class SslCertificate
{
    /// <summary>
    /// Custom hostname SSL identifier tag
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// The time on which the custom certificate was created
    /// </summary>
    [JsonProperty("issued_on")]
    public DateTime? IssuedOn { get; set; }

    /// <summary>
    /// The time the custom certificate expires on
    /// </summary>
    [JsonProperty("expires_on")]
    public DateTime? ExpiresOn { get; set; }

    /// <summary>
    /// The time the custom certificate was uploaded
    /// </summary>
    [JsonProperty("uploaded_on")]
    public DateTime? UploadedOn { get; set; }

    /// <summary>
    /// The issuer on a custom uploaded certificate
    /// </summary>
    [JsonProperty("issuer")]
    public string Issuer { get; set; }

    /// <summary>
    /// The serial number on a custom uploaded certificate
    /// </summary>
    [JsonProperty("serial_number")]
    public string SerialNumber { get; set; }

    /// <summary>
    /// The signature on a custom uploaded certificate
    /// </summary>
    [JsonProperty("signature")]
    public string Signature { get; set; }

    /// <summary>
    /// The SHA256 fingerprint on a custom uploaded certificate
    /// </summary>
    [JsonProperty("fingerprint_sha256")]
    public string FingerprintSha256 { get; set; }
}
