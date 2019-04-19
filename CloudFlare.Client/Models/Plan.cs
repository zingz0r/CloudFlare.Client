using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class Plan
    {
        /// <summary>
        /// Plan id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Plan name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The price of the subscription that is be billed
        /// </summary>
        [JsonProperty("price")]
        public int Price { get; set; }

        /// <summary>
        /// The monetary unit in which pricing information is displayed
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// How often the subscription is renewed automatically
        /// </summary>
        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        /// <summary>
        /// Legacy id
        /// </summary>
        [JsonProperty("legacy_id")]
        public LegacyType LegacyId { get; set; }

        /// <summary>
        /// Whether it is subscribed
        /// </summary>
        [JsonProperty("is_subscribed")]
        public bool IsSubscribed { get; set; }

        /// <summary>
        /// Whether it can be subscribed
        /// </summary>
        [JsonProperty("can_subscribe")]
        public bool CanSubscribe { get; set; }

    }
}