using Newtonsoft.Json;

namespace CloudFlare.Client.Api.CustomHostname
{
    public class PostCustomHostname
    {
        /// <summary>
        /// The custom hostname that will point to your hostname via CNAME
        /// </summary>
        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// SSL properties used when creating the custom hostname
        /// </summary>
        [JsonProperty("ssl")]
        public PostCustomHostnameSsl Ssl { get; set; }
    }

    public class PostCustomHostnameSsl
    {
        /// <summary>
        /// Domain control validation (DCV) method used for this hostname
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// Level of validation to be used for this hostname. Domain validation (dv) must be used
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// SSL specific settings
        /// </summary>
        [JsonProperty("settings")]
        public PostCustomHostnameSslSettings Settings { get; set; }
    }

    public class PostCustomHostnameSslSettings
    {
        /// <summary>
        /// Whether or not HTTP2 is enabled
        /// </summary>
        [JsonProperty("http2")]
        public string Http2 { get; set; }

        /// <summary>
        /// The minimum TLS version supported
        /// </summary>
        [JsonProperty("min_tls_version")]
        public string MinTlsVersion { get; set; }

        /// <summary>
        /// Whether or not TLS 1.3 is enabled
        /// </summary>
        [JsonProperty("tls_1_3")]
        public string Tls13 { get; set; }

        /// <summary>
        /// A whitelist of ciphers for TLS termination. These ciphers must be in the BoringSSL format
        /// </summary>
        [JsonProperty("ciphers")]
        public string[] Ciphers { get; set; }
    }
}