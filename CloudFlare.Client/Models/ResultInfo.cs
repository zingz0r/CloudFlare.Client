using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class ResultInfo
    {
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        public int Count { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }
}
