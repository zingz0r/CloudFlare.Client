using System;
using System.Collections.Generic;
using CloudFlare.Client.Api.Result;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones;

/// <summary>
/// Represents the SSL setting response.
/// </summary>
/// <typeparam name="T">The type of the setting value.</typeparam>
public class ZoneSetting<T>
{
    /// <summary>
    /// The ID of the setting.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// The value of the setting.
    /// </summary>
    [JsonProperty("value")]
    public T Value { get; set; }

    /// <summary>
    /// The last time this setting was modified.
    /// </summary>
    [JsonProperty("modified_on")]
    public DateTime? ModifiedDate { get; set; }

    /// <summary>
    /// The status of the certificate.
    /// </summary>
    [JsonProperty("certificate_status")]
    public string CertificateStatus { get; set; }

    /// <summary>
    /// Any validation errors related to the SSL certificate.
    /// </summary>
    [JsonProperty("validation_errors")]
    public IReadOnlyList<ErrorDetails> ValidationErrors { get; set; }

    /// <summary>
    /// Indicates whether this setting can be modified.
    /// </summary>
    [JsonProperty("editable")]
    public bool Editable { get; set; }
}
