using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Parameters.Data
{
    public class Srv : IData
    {
        public Srv()
        {

        }

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
        /// <para>Name of the SRV record</para>
        /// <para>Use @ for root</para>
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Used with some records like MX and SRV to determine priority.
        /// If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        [JsonProperty("priority")]
        public int Priority { get; set; }

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
