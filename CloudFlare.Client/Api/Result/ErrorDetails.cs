using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Result
{
    /// <summary>
    /// Error details
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Integer error code
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
