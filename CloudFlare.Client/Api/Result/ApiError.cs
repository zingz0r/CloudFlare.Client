using System.Collections.Generic;
using Newtonsoft.Json;

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
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Error chain
        /// </summary>
        [JsonProperty("error_chain")]
        public IReadOnlyList<ErrorDetails> ErrorChain { get; set; }
    }
}
