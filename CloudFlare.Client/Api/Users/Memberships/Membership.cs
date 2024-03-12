using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Users.Memberships
{
    /// <summary>
    /// Membership
    /// </summary>
    public class Membership
    {
        /// <summary>
        /// Membership identifier tag
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The unique activation code for the account membership
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// A member's status in the account
        /// </summary>
        [JsonPropertyName("status")]
        public MembershipStatus Status { get; set; }

        /// <summary>
        /// Membership entity object (Account/User)
        /// </summary>
        [JsonPropertyName("account")]
        public Account Account { get; set; }

        /// <summary>
        /// Roles assigned to a member
        /// </summary>
        [JsonPropertyName("roles")]
        public IReadOnlyList<string> Roles { get; set; }

        /// <summary>
        /// All access permissions for the User at the Account
        /// </summary>
        [JsonPropertyName("permissions")]
        public IDictionary<string, Permission> Permissions { get; set; }
    }
}
