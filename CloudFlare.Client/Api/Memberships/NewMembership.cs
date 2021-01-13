using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Memberships
{
    public class NewMembership
    {
        /// <summary>
        /// Your contact email address
        /// </summary>
        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// A member's status in the account
        /// </summary>
        [JsonProperty("status")]
        public MembershipStatus Status { get; set; }

        /// <summary>
        /// Array of roles associated with this member
        /// </summary>
        [JsonProperty("roles")]
        public IReadOnlyList<Role> Roles { get; set; }
    }
}