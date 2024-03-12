using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    /// <summary>
    /// New custom hostname
    /// </summary>
    public class NewCustomHostname
    {
        /// <summary>
        /// The custom hostname that will point to your hostname via CNAME
        /// </summary>
        [JsonPropertyName("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// SSL settings used when creating the custom hostname
        /// </summary>
        [JsonPropertyName("ssl")]
        public Ssl Ssl { get; set; }
    }
}
