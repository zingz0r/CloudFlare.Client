using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Accounts.Subscriptions
{
    /// <summary>
    /// Component value
    /// </summary>
    public class ComponentValue
    {
        /// <summary>
        /// The name of the component
        /// </summary>
        [JsonPropertyName("name")]
        public ComponentValueType Name { get; set; }

        /// <summary>
        /// The value of the component
        /// </summary>
        [JsonPropertyName("value")]
        public long Value { get; set; }

        /// <summary>
        /// The default value of the component
        /// </summary>
        [JsonPropertyName("default")]
        public long Default { get; set; }

        /// <summary>
        /// The price of the component
        /// </summary>
        [JsonPropertyName("price")]
        public long Price { get; set; }
    }
}
