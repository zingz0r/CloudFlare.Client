using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones
{
    /// <summary>
    /// Modified zone
    /// </summary>
    public class ModifiedZone
    {
        /// <summary>
        /// Whether the zone is paused
        /// </summary>
        [JsonProperty("paused")]
        public bool? Paused { get; set; }

        /// <summary>
        /// An array of domains used for custom name servers. This is only available for Business and Enterprise plans.
        /// </summary>
        [JsonProperty("vanity_name_servers")]
        [DataMember(EmitDefaultValue = false)]
        public IReadOnlyList<string> VanityNameServers { get; set; }

        /// <summary>
        /// Plan of the zone
        /// </summary>
        [JsonProperty("plan")]
        [DataMember(EmitDefaultValue = false)]
        public Plan Plan { get; set; }
    }
}
