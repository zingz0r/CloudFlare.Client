using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Parameters.Data
{
    /// <summary>
    /// Srv
    /// </summary>
    public class Srv : IData
    {
        /// <summary>
        /// Service name of the SRV record
        /// </summary>
        [JsonPropertyName("service")]
        public string Service { get; set; }

        /// <summary>
        /// Protocol of the SRV record
        /// </summary>
        [JsonPropertyName("proto")]
        public Protocol Protocol { get; set; }

        /// <summary>
        /// <para>Name of the SRV record</para>
        /// <para>Use @ for root</para>
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Used with some records like MX and SRV to determine priority.
        /// If you do not supply a priority for an MX record, a default value of 0 will be set
        /// </summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// Weight of the SRV record
        /// </summary>
        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        /// <summary>
        /// Port of the SRV record
        /// </summary>
        [JsonPropertyName("port")]
        public int Port { get; set; }

        /// <summary>
        /// Target of the SRV record
        /// </summary>
        [JsonPropertyName("target")]
        public string Target { get; set; }
    }
}
