using System;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

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
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Account name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Additional account settings
        /// </summary>
        [JsonProperty("settings")]
        public AdditionalAccountSettings Settings { get; set; }

        /// <summary>
        /// Account Type
        /// </summary>
        [JsonProperty("type")]
        public AccountType Type { get; set; }

        /// <summary>
        /// Account creation date
        /// </summary>
        [JsonProperty("created_on")]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Legacy flags
        /// </summary>
        [JsonProperty("legacy_flags")]
        public LegacyFlags LegacyFlags { get; set; }
    }
}
