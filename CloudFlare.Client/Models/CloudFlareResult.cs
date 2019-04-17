using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using CloudFlare.Client.Api;
using Newtonsoft.Json.Serialization;

namespace CloudFlare.Client.Models
{
    public class CloudFlareResult<TK>
    {
        public TK Result { get; set; }

        public ResultInfo ResultInfo { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> Messages { get; set; }

        public IEnumerable<ApiError> Errors { get; set; }
    }
}
