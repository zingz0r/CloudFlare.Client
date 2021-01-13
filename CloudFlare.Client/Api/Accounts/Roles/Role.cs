using System.Collections.Generic;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts.Roles
{
    public class Role
    {
        /// <summary>
        /// Role identifier tag
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Role Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of role's permissions
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Access permissions for a Role
        /// </summary>
        [JsonProperty("permissions")]
        public Dictionary<string, Permission> Permissions { get; set; }
    }
}
