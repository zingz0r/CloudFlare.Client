using System;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api
{
    public class TimingInfo
    {
        [JsonProperty("start_time")]
        public DateTime StartDateTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndDateTime { get; set; }

        [JsonProperty("process_time")]
        public int ProcessTime { get; set; }
    }
}
