using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    public class NewCustomHostname
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
        public CustomHostnameSsl Ssl { get; set; }
    }
}
