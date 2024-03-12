using System;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Zones.CustomHostnames
{
    /// <summary>
    /// Verification of the ownership
    /// </summary>
    public class OwnershipVerification
    {
        /// <summary>
        /// Type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Nane
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [JsonPropertyName("value")]
        public Guid Value { get; set; }
    }
}
