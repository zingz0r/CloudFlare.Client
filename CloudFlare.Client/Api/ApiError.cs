using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api
{
    public class ApiError
    {
        public int Code { get; set; }

        public string Message { get; set; }

        [JsonProperty("error_chain")]
        public IEnumerable<ErrorDetails> ErrorChain { get; set; }
    }
}