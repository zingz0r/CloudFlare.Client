using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Zones
{
    /// <summary>
    /// Owner
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Type of the owner
        /// </summary>
        [JsonPropertyName("type")]
        public OwnerType Type { get; set; }
    }
}
