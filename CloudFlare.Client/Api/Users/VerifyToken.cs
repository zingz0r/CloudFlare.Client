using System;
using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Users
{
    /// <summary>
    /// Verify token
    /// </summary>
    public class VerifyToken
    {
        /// <summary>
        /// Membership identifier tag
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Token name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Status of this membership
        /// </summary>
        [JsonPropertyName("status")]
        public TokenStatus Status { get; set; }

        /// <summary>
        /// The expiration time on or after which the JWT MUST NOT be accepted for processing
        /// </summary>
        [JsonPropertyName("expires_on")]
        public DateTime ExpiresOn { get; set; }

        /// <summary>
        /// The time on which the token was created
        /// </summary>
        [JsonPropertyName("issued_on")]
        public DateTime IssuedOn { get; set; }

        /// <summary>
        /// Last time the token was modified
        /// </summary>
        [JsonPropertyName("modified_on")]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// The time before which the token MUST NOT be accepted for processing
        /// </summary>
        [JsonPropertyName("not_before")]
        public DateTime NotBefore { get; set; }
    }
}
