using System.Collections.Generic;

namespace CloudFlare.Client.Api.Result
{
    public class CloudFlareResult<T>
    {
        /// <summary>
        /// Generic result property
        /// </summary>
        public T Result { get; }

        /// <summary>
        /// Additional pagination info
        /// </summary>
        public ResultInfo ResultInfo { get; }

        /// <summary>
        /// Success flag
        /// </summary>
        public bool Success { get; }

        /// <summary>
        /// Additional messages
        /// </summary>
        public IReadOnlyList<ErrorDetails> Messages { get; }

        /// <summary>
        /// Array of potential errors
        /// </summary>
        public IReadOnlyList<ApiError> Errors { get; }

        /// <summary>
        /// Time info of procession
        /// </summary>
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
