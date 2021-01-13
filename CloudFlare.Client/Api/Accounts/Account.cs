using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts
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

        /// <summary>
        /// Additional Account Properties
        /// </summary>
        [JsonProperty("settings")]
        public AdditionalAccountProperties AdditionalAccountProperties { get; set; }
    }
}
