using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Api.Parameters
{
    public class MemberUpdateSettings
    {
        /// <summary>
        /// The unique activation code for the account membership
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// User object
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// A member's status in the account
        /// </summary>
        public MembershipStatus? Status { get; set; }
    }
}