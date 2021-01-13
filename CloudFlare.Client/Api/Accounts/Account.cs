using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts
{
    public class Account
    {
        /// <summary>
        /// AccountEndpoints id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// AccountEndpoints name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// AccountEndpoints additionalAccountProperties
        /// </summary>
        [JsonProperty("additionalAccountProperties")]
        public AdditionalAccountProperties AdditionalAccountProperties { get; set; }
    }
}
