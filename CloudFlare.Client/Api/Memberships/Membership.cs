using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using Newtonsoft.Json;

namespace CloudFlare.Client.Api.Memberships
{
    public class Membership<T, TRole>
    {
        /// <summary>
        /// MembershipEndpoints identifier tag
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
        /// MembershipEndpoints information
        /// </summary>
        [JsonProperty((nameof(T)))]
        public T Entity { get; set; }

        /// <summary>
        /// Roles assigned to a member
        /// </summary>
        [JsonProperty("roles")]
        public IReadOnlyList<TRole> Roles { get; set; }

        /// <summary>
        /// All access permissions for the User at the Account
        /// </summary>
        [JsonProperty("permissions")]
        public IDictionary<string, Permission> Permissions { get; set; }
    }
}