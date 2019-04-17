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
        public IEnumerable<string> Messages { get; set; } // TODO!

        /// <summary>
        /// Array of potential errors
        /// </summary>
        public IEnumerable<ApiError> Errors { get; set; }
    }
}
