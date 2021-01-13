using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Memberships
{
    public class AdditionalMembershipSettings<T>
    {
        /// <summary>
        /// The unique activation code for the account membership
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Entity object (Account/User)
        /// </summary>
        public T Entity { get; set; }
        /// <summary>
        /// A member's status in the account
        /// </summary>
        public MembershipStatus? Status { get; set; }
    }
}