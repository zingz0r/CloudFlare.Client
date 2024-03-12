using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Result
{
    /// <summary>
    /// Stores data of the result from CloudFlare
    /// </summary>
    /// <typeparam name="T">Type of the result</typeparam>
    public class CloudFlareResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareResult{T}"/> class
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

        /// <summary>
        /// Generic result property
        /// </summary>
        [JsonPropertyName("result")]
        public T Result { get; }

        /// <summary>
        /// Additional pagination info
        /// </summary>
        [JsonPropertyName("result_info")]
        public ResultInfo ResultInfo { get; }

        /// <summary>
        /// Success flag
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; }

        /// <summary>
        /// Additional messages
        /// </summary>
        [JsonPropertyName("messages")]
        public IReadOnlyList<ErrorDetails> Messages { get; }

        /// <summary>
        /// Array of potential errors
        /// </summary>
        [JsonPropertyName("errors")]
        public IReadOnlyList<ApiError> Errors { get; }

        /// <summary>
        /// Time info of procession
        /// </summary>
        [JsonPropertyName("timing")]
        public TimingInfo Timing { get; }
    }
}
