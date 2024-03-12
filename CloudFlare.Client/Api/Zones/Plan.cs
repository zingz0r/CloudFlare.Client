using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones
{
    /// <summary>
    /// Plan
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// Plan id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Plan name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The price of the subscription that is be billed
        /// </summary>
        [JsonPropertyName("price")]
        public int? Price { get; set; }

        /// <summary>
        /// The monetary unit in which pricing information is displayed
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// How often the subscription is renewed automatically
        /// </summary>
        [JsonPropertyName("frequency")]
        public Frequency? Frequency { get; set; }

        /// <summary>
        /// Legacy id
        /// </summary>
        [JsonPropertyName("legacy_id")]
        public LegacyType? LegacyId { get; set; }

        /// <summary>
        /// Whether it is subscribed
        /// </summary>
        [JsonPropertyName("is_subscribed")]
        public bool? IsSubscribed { get; set; }

        /// <summary>
        /// Whether it can be subscribed
        /// </summary>
        [JsonPropertyName("can_subscribe")]
        public bool? CanSubscribe { get; set; }
    }
}
