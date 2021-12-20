using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Result
{
    public class CloudFlareResult<T>
    {
        /// <summary>
        /// Generic result property
        /// </summary>
        [JsonProperty("result")]
        public T Result { get; }

        /// <summary>
        /// Additional pagination info
        /// </summary>
        [JsonProperty("result_info")]
        public ResultInfo ResultInfo { get; }

        /// <summary>
        /// Success flag
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; }

        /// <summary>
        /// Additional messages
        /// </summary>
        [JsonProperty("messages")]
        public IReadOnlyList<ErrorDetails> Messages { get; }

        /// <summary>
        /// Array of potential errors
        /// </summary>
        [JsonProperty("errors")]
        public IReadOnlyList<ApiError> Errors { get; }

        /// <summary>
        /// Time info of procession
        /// </summary>
        [JsonProperty("timing")]
        public TimingInfo Timing { get; }

        /// <summary>
        /// Constructor for CloudFlareResult
        /// </summary>
        /// <param name="result">Result</param>
        /// <param name="resultInfo">Result info</param>
        /// <param name="success">Success</param>
        /// <param name="messages">Messages</param>
        /// <param name="errors">Errors</param>
        /// <param name="timing">Timing</param>
        public CloudFlareResult(T result, ResultInfo resultInfo, bool success, IReadOnlyList<ErrorDetails> messages, IReadOnlyList<ApiError> errors, TimingInfo timing)
        {
            Result = result;
            ResultInfo = resultInfo;
            Success = success;
            Messages = messages;
            Errors = errors;
            Timing = timing;
        }
    }
}
