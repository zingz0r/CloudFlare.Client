using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Result
{
    /// <summary>
    /// API errors
    /// </summary>
    public class ApiError
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

        /// <summary>
        /// Error chain
        /// </summary>
        [JsonPropertyName("error_chain")]
        public IReadOnlyList<ErrorDetails> ErrorChain { get; set; }
    }
}
