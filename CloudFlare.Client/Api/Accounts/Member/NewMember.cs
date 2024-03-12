using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Accounts.Member
{
    /// <summary>
    /// New member
    /// </summary>
    public class NewMember
    {
        /// <summary>
        /// Your contact email address
        /// </summary>
        [JsonPropertyName("email")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// A member's status in the account
        /// </summary>
        [JsonPropertyName("status")]
        public MembershipStatus Status { get; set; }

        /// <summary>
        /// Array of roles associated with this member
        /// </summary>
        [JsonPropertyName("roles")]
        public IReadOnlyList<Role> Roles { get; set; }
    }
}
