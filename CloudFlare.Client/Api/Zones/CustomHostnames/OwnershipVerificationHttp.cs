using System;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    public class OwnershipVerificationHttp
    {
        [JsonProperty("http_url")]
        public Uri HttpUrl { get; set; }

        [JsonProperty("http_body")]
        public Guid HttpBody { get; set; }
    }
}