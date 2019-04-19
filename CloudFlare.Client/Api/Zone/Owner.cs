using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CloudFlare.Client.Api.Zone
{
    public class Owner
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Type of the owner
        /// </summary>
        [JsonProperty("type")]
        public OwnerType Type { get; set; }

    }
}
