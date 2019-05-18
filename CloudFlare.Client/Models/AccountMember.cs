using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Models
{
    public class AccountMember
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
        /// A member's status in the account
        /// </summary>
        [JsonProperty("status")]
        public MembershipStatus Status { get; set; }

        /// <summary>
        /// Account information
        /// </summary>
        [JsonProperty("user")]
        public User User { get; set; }

        /// <summary>
        /// Roles assigned to a member
        /// </summary>
        [JsonProperty("roles")]
        public IEnumerable<AccountRole> Roles { get; set; }
    }
}