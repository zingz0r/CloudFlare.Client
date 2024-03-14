using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Enumerators;

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
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The unique activation code for the account member
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// A member's status in the account
        /// </summary>
        [JsonPropertyName("status")]
        public MembershipStatus Status { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; set; }

        /// <summary>
        /// Roles assigned to a member
        /// </summary>
        [JsonPropertyName("roles")]
        public IReadOnlyList<Role> Roles { get; set; }
    }
}
