using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Accounts.Member
{
    public class AdditionalMemberSettings
    {
        /// <summary>
        /// The unique activation code for the account member
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Member user
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// A member's status in the account
        /// </summary>
        public Status? Status { get; set; }
    }
}