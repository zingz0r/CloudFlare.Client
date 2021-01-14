using System;
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
        /// Token name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Status of this membership
        /// </summary>
        [JsonProperty("status")]
        public VerifyTokenStatus Status { get; set; }

        /// <summary>
        /// The expiration time on or after which the JWT MUST NOT be accepted for processing
        /// </summary>
        [JsonProperty("expires_on")]
        public DateTime ExpiresOn { get; set; }

        /// <summary>
        /// The time on which the token was created
        /// </summary>
        [JsonProperty("issued_on")]
        public DateTime IssuedOn { get; set; }

        /// <summary>
        /// Last time the token was modified
        /// </summary>
        [JsonProperty("modified_on")]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// The time before which the token MUST NOT be accepted for processing
        /// </summary>
        [JsonProperty("not_before")]
        public DateTime NotBefore { get; set; }
    }
}
