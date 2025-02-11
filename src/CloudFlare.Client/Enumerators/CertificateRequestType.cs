using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Enumerators;

/// <summary>
/// Signature type desired on certificate.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum CertificateRequestType
{
    /// <summary>
    /// Origin RSA.
    /// </summary>
    [EnumMember(Value = "origin-rsa")]
    OriginRsa,

    /// <summary>
    /// Origin ECC.
    /// </summary>
    [EnumMember(Value = "origin-ecc")]
    OriginEcc,

    /// <summary>
    /// Custom RSA.
    /// </summary>
    [EnumMember(Value = "custom-rsa")]
    KeylessCertificate
}
