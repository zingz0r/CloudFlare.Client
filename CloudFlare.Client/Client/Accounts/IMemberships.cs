using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Memberships;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Users;

namespace CloudFlare.Client.Client.Accounts
{
    public interface IMemberships
    {
        /// <summary>
        /// Add a user to the list of members for this account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="emailAddress">Your contact email address</param>
        /// <param name="roles">Array of roles associated with this member</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Membership<User, Role>>> AddAsync(string accountId, string emailAddress, IReadOnlyList<Role> roles, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove a member from an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">MembershipEndpoints identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Membership<User, Role>>> DeleteAsync(string accountId, string memberId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="displayOptions">Display Options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Membership<User, Role>>>> GetAsync(string accountId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information about a specific member of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">MembershipEndpoints identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Membership<User, Role>>> GetDetailsAsync(string accountId, string memberId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="settings">Additional account settings</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Membership<User, Role>>> UpdateAsync(string accountId, string memberId, IReadOnlyList<Role> roles, AdditionalMembershipSettings<User> settings = null, CancellationToken cancellationToken = default);
    }
}