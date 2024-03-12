using System.Text.Json.Serialization;

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
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
