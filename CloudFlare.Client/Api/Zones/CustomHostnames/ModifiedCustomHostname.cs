using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    /// <summary>
    /// Modified custom hostname
    /// </summary>
    public class ModifiedCustomHostname
    {
        /// <summary>
        /// SSL settings used when creating the custom hostname
        /// </summary>
        [JsonPropertyName("ssl")]
        [DataMember(EmitDefaultValue = false)]
        public Ssl Ssl { get; set; }

        /// <summary>
        /// Custom metadata
        /// </summary>
        [JsonPropertyName("custom_metadata")]
        public IReadOnlyDictionary<string, string> CustomMetadata { get; set; }

        /// <summary>
        /// Custom origin server
        /// </summary>
        [JsonPropertyName("custom_origin_server")]
        public string CustomOriginServer { get; set; }
    }
}
