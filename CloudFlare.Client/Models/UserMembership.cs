using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class UserMembership
    {
        /// <summary>
        /// Membership identifier tag
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The unique activation code for the account membership
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Status of this membership
        /// </summary>
        [JsonProperty("status")]
        public MembershipStatus Status { get; set; }

        /// <summary>
        /// Account information
        /// </summary>
        [JsonProperty("account")]
        public Account Account { get; set; }

        /// <summary>
        /// List of role names for the User at the Account
        /// </summary>
        [JsonProperty("roles")]
        public IReadOnlyList<string> Roles { get; set; }

        /// <summary>
        /// All access permissions for the User at the Account
        /// </summary>
        [JsonProperty("permissions")]
        public IDictionary<string,Permission> Permissions { get; set; }
    }
}