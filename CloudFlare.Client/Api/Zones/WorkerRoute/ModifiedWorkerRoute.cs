using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Zones.WorkerRoute
{
    /// <summary>
    /// Modified worker route
    /// </summary>
    public class ModifiedWorkerRoute
    {
        /// <summary>
        /// Pattern to match a url
        /// </summary>
        /// <example>
        /// example.net/*
        /// </example>
        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }

        /// <summary>
        /// Name of the script
        /// </summary>
        /// <example>
        /// this-is_my_script-01
        /// </example>
        [JsonPropertyName("script")]
        public string Script { get; set; }
    }
}
