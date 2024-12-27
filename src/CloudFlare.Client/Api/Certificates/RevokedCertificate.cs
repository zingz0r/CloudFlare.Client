using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Certificates
{
    /// <summary>
    /// Certificate
    /// </summary>
    public class RevokedCertificate
    {
        /// <summary>
        /// Unique identifier for the certificate.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
