using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class Account
    {
        /// <summary>
        /// Account id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Account name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
