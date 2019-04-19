using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zone
{
    public class PatchZone
    {
        /// <summary>
        /// <see cref="Models.Zone.Paused"/>
        /// </summary>
        [JsonProperty("paused")]
        public bool Paused { get; set; }

        /// <summary>
        /// An array of domains used for custom name servers. This is only available for Business and Enterprise plans.
        /// </summary>
        [JsonProperty("vanity_name_servers")]
        public IEnumerable<string> VanityNameServers { get; set; }

        /// <summary>
        /// <see cref="Models.Zone.Plan"/>
        /// </summary>
        [JsonProperty("plan")]
        public Plan Plan { get; set; }
    }
}