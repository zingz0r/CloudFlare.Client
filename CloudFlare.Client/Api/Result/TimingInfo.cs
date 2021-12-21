using System;
using Newtonsoft.Json;

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
        [JsonProperty("start_time")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// End date and time of the execution
        /// </summary>
        [JsonProperty("end_time")]
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Process time of the execution
        /// </summary>
        [JsonProperty("process_time")]
        public int ProcessTime { get; set; }
    }
}
