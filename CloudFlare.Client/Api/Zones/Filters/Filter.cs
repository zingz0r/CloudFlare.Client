using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.Filters
{
    /// <summary>
    /// Filter
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// A note that you can use to describe the purpose of the filter
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Filter expression
        /// </summary>
        [JsonProperty("expression")]
        public string Expression { get; set; }

        /// <summary>
        /// Filter identifier
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Whether this filter is currently paused
        /// </summary>
        [JsonProperty("paused")]
        public bool Paused { get; set; }

        /// <summary>
        /// Short reference tag to quickly select related rules.
        /// </summary>
        [JsonProperty("ref")]
        public string Ref { get; set; }
    }
}
