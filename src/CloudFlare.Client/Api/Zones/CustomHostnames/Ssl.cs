using System.Collections.Generic;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames;

/// <summary>
/// Ssl
/// </summary>
public class Ssl
{
    /// <summary>
    /// SSL identifier tag
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Status of the hostname's SSL certificates
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }

    /// <summary>
    /// Domain control validation (DCV) method used for this hostname
    /// </summary>
    [JsonProperty("method")]
    public MethodType Method { get; set; }

    /// <summary>
    /// Level of validation to be used for this hostname. Domain validation (dv) must be used
    /// </summary>
    [JsonProperty("type")]
    public DomainValidationType Type { get; set; }

    /// <summary>
    /// Certificate's required validation records
    /// </summary>
    [JsonProperty("validation_records")]
    public CustomHostnameSslValidationRecord[] ValidationRecords { get; set; }

    /// <summary>
    /// Certificate's validation errors
    /// </summary>
    [JsonProperty("validation_errors")]
    public IReadOnlyList<ErrorDetails> ValidationErrors { get; set; }

    /// <summary>
    /// The valid hosts for the certificate
    /// </summary>
    [JsonProperty("hosts")]
    public IReadOnlyList<string> Hosts { get; set; }

    /// <summary>
    /// Certificates
    /// </summary>
    [JsonProperty("certificates")]
    public SslCertificate[] Certificates { get; set; }

    /// <summary>
    /// The value that must be returned when the CNAME (cname) is queried during domain validation
    /// </summary>
    [JsonProperty("cname_target")]
    public string CnameTarget { get; set; }

    /// <summary>
    /// The CNAME that the certificate authority (CA) will resolve during the domain validation
    /// </summary>
    [JsonProperty("cname")]
    public string Cname { get; set; }

    /// <summary>
    /// The Certificate Authority that has issued this certificate
    /// </summary>
    [JsonProperty("certificate_authority")]
    public string CertificateAuthority { get; set; }

    /// <summary>
    /// A ubiquitous bundle has the highest probability of being verified everywhere, even by clients using outdated or unusual trust stores.
    /// An optimal bundle uses the shortest chain and newest intermediates.
    /// And the force bundle verifies the chain, but does not otherwise modify it.
    /// </summary>
    [JsonProperty("bundle_method")]
    public string BundleMethod { get; set; }

    /// <summary>
    /// Indicates whether the certificate covers a wildcard
    /// </summary>
    [JsonProperty("wildcard")]
    public bool Wildcard { get; set; }

    /// <summary>
    /// Additional SSL specific settings
    /// </summary>
    [JsonProperty("settings")]
    public AdditionalCustomHostnameSslSettings Settings { get; set; }
}
