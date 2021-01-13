using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones
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
