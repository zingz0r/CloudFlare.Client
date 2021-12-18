using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Parameters.Data
{
    public class Srv : IData
    {
        /// <summary>
        /// Service name of the SRV record
        /// </summary>
        [JsonProperty("service")]
        public string Service { get; set; }

        /// <summary>
        /// Protocol of the SRV record
        /// </summary>
        [JsonProperty("proto")]
        public Protocol Protocol { get; set; }

        /// <summary>
        /// Name of the SRV record
        /// Use @ for root
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Priority of the SRV record
        /// </summary>
        [JsonProperty("priority")]
        public long Priority { get; set; }

        /// <summary>
        /// Weight of the SRV record
        /// </summary>
        [JsonProperty("weight")]
        public int Weight { get; set; }

        /// <summary>
        /// Port of the SRV record
        /// </summary>
        [JsonProperty("port")]
        public int Port { get; set; }

        /// <summary>
        /// Target of the SRV record
        /// </summary>
        [JsonProperty("target")]
        public string Target { get; set; }
    }
}
