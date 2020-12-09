using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Result
{
    public class ApiError
    {
        /// <summary>
        /// Integer error code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Error chain
        /// </summary>
        [JsonProperty("error_chain")]
        public IReadOnlyList<ErrorDetails> ErrorChain { get; set; }
    }
}