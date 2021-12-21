using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Accounts.Member
{
    /// <summary>
    /// Member
    /// </summary>
    public class Member
    {
        /// <summary>
        /// Member identifier tag
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The unique activation code for the account member
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// A member's status in the account
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// Roles assigned to a member
        /// </summary>
        [JsonProperty("roles")]
        public IReadOnlyList<Role> Roles { get; set; }
    }
}
