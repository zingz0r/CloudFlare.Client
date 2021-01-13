using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Authentication
{
    public class VerifyToken
    {
        /// <summary>
        /// Membership identifier tag
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Status of this membership
        /// </summary>
        [JsonProperty("status")]
        public VerifyTokenStatus Status { get; set; }
    }
}
