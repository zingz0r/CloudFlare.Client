using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class ComponentValue
    {
        /// <summary>
        /// The name of the component
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The value of the component
        /// </summary>
        [JsonProperty("value")]
        public long Value { get; set; }

        /// <summary>
        /// The default value of the component
        /// </summary>
        [JsonProperty("default")]
        public long Default { get; set; }

        /// <summary>
        /// The price of the component
        /// </summary>
        [JsonProperty("price")]
        public long Price { get; set; }
    }
}