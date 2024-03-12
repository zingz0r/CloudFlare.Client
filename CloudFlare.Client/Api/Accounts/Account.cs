using System;
using System.Text.Json.Serialization;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Accounts
{
    /// <summary>
    /// Account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Account name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Additional account settings
        /// </summary>
        [JsonPropertyName("settings")]
        public AdditionalAccountSettings Settings { get; set; }

        /// <summary>
        /// Account Type
        /// </summary>
        [JsonPropertyName("type")]
        public AccountType Type { get; set; }

        /// <summary>
        /// Account creation date
        /// </summary>
        [JsonPropertyName("created_on")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Legacy flags
        /// </summary>
        [JsonPropertyName("legacy_flags")]
        public LegacyFlags LegacyFlags { get; set; }
    }
}
