using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Result
{
    public class ResultInfo
    {
        /// <summary>
        /// Page number of paginated results

        /// </summary>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// Number of results per page
        /// </summary>
        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        /// <summary>
        /// When count is provided, the response will contain up to count results.
        /// Since results are not sorted, you are likely to get different data for repeated requests.
        /// Count must be an integer > 0.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// Total count of the response
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }
}
