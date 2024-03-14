using System;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Result
{
    /// <summary>
    /// Timing information
    /// </summary>
    public class TimingInfo
    {
        /// <summary>
        /// Start date and time of the execution
        /// </summary>
        [JsonPropertyName("start_time")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// End date and time of the execution
        /// </summary>
        [JsonPropertyName("end_time")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Process time of the execution
        /// </summary>
        [JsonPropertyName("process_time")]
        public int ProcessTime { get; set; }
    }
}
