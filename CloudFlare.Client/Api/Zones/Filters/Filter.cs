using System.Text.Json.Serialization;

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
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Filter expression
        /// </summary>
        [JsonPropertyName("expression")]
        public string Expression { get; set; }

        /// <summary>
        /// Filter identifier
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Whether this filter is currently paused
        /// </summary>
        [JsonPropertyName("paused")]
        public bool Paused { get; set; }

        /// <summary>
        /// Short reference tag to quickly select related rules.
        /// </summary>
        [JsonPropertyName("ref")]
        public string Ref { get; set; }
    }
}
