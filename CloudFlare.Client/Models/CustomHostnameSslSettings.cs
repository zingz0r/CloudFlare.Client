using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class CustomHostnameSslSettings
    {
        /// <summary>
        /// Whether or not HTTP2 is enabled
        /// </summary>
        [JsonProperty("http2")]
        public FeatureStatus Http2 { get; set; }

        /// <summary>
        /// The minimum TLS version supported
        /// </summary>
        [JsonProperty("min_tls_version")]
        public TlsVersion MinTlsVersion { get; set; }

        /// <summary>
        /// Whether or not TLS 1.3 is enabled
        /// </summary>
        [JsonProperty("tls_1_3")]
        public FeatureStatus Tls13 { get; set; }

        /// <summary>
        /// A whitelist of ciphers for TLS termination. These ciphers must be in the BoringSSL format
        /// </summary>
        [JsonProperty("ciphers")]
        public IEnumerable<string> Ciphers { get; set; }
    }
}
