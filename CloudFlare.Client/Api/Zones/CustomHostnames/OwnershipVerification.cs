using System;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    public class OwnershipVerification
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public Guid Value { get; set; }
    }
}