using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudFlare.Client.Api.Accounts.Roles
{
    /// <summary>
    /// Role
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Role identifier tag
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Role Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of role's permissions
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Access permissions for a Role
        /// </summary>
        [JsonPropertyName("permissions")]
        public Dictionary<string, Permission> Permissions { get; set; }
    }
}
