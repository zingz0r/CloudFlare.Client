using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Result
{
    /// <summary>
    /// Additional information about the result
    /// </summary>
    public class ResultInfo
    {
        /// <summary>
        /// Page number of paginated results
        /// </summary>
        [JsonPropertyName("page")]
        public int Page { get; set; }

        /// <summary>
        /// Number of results per page
        /// </summary>
        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        /// <summary>
        /// Total count of the pages
        /// </summary>
        [JsonPropertyName("total_pages")]
        public int TotalPage { get; set; }

        /// <summary>
        /// When count is provided, the response will contain up to count results.
        /// Since results are not sorted, you are likely to get different data for repeated requests.
        /// Count must be an integer > 0.
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

        /// <summary>
        /// Total count of the response
        /// </summary>
        [JsonPropertyName("total_count")]
        public int TotalCount { get; set; }
    }
}
