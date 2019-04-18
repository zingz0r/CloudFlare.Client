using System.Collections.Generic;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Api
{
    public class CloudFlareResult<T>
    {
        /// <summary>
        /// Generic result property
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// Additional pagination info
        /// </summary>
        public ResultInfo ResultInfo { get; set; }

        /// <summary>
        /// Success flag
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Additional messages
        /// </summary>
        public IEnumerable<ErrorDetails> Messages { get; set; }

        /// <summary>
        /// Array of potential errors
        /// </summary>
        public IEnumerable<ApiError> Errors { get; set; }

        /// <summary>
        /// Time info of procession
        /// </summary>
        public TimingInfo Timing { get; set; }
    }
}
