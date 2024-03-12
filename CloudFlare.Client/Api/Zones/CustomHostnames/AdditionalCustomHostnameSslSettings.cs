using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    /// <summary>
    /// Additional custom hostname ssl settings
    /// </summary>
    public class AdditionalCustomHostnameSslSettings
    {
        /// <summary>
        /// Whether or not HTTP2 is enabled
        /// </summary>
        [JsonPropertyName("http2")]
        public FeatureStatus Http2 { get; set; }

        /// <summary>
        /// The minimum TLS version supported
        /// </summary>
        [JsonPropertyName("min_tls_version")]
        public TlsVersion MinTlsVersion { get; set; }

        /// <summary>
        /// Whether or not TLS 1.3 is enabled
        /// </summary>
        [JsonPropertyName("tls_1_3")]
        public FeatureStatus Tls13 { get; set; }

        /// <summary>
        /// A whitelist of ciphers for TLS termination. These ciphers must be in the BoringSSL format
        /// </summary>
        [JsonPropertyName("ciphers")]
        public IReadOnlyList<string> Ciphers { get; set; }
    }
}
