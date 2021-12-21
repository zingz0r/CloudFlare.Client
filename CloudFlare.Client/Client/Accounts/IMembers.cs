using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Member;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Client.Accounts
{
    /// <summary>
    /// Interface for interacting with members
    /// </summary>
    public interface IMembers
    {
        /// <summary>
        /// Add a user to the list of members for this account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="newMember">Member to add</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created member</returns>
        Task<CloudFlareResult<Member>> AddAsync(string accountId, NewMember newMember, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove a member from an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The deleted member</returns>
        Task<CloudFlareResult<Member>> DeleteAsync(string accountId, string memberId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="displayOptions">Display Options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The requested member</returns>
        Task<CloudFlareResult<IReadOnlyList<Member>>> GetAsync(string accountId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information about a specific member of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The requested member details</returns>
        Task<CloudFlareResult<Member>> GetDetailsAsync(string accountId, string memberId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="member">Modified member</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated member</returns>
        Task<CloudFlareResult<Member>> UpdateAsync(string accountId, Member member, CancellationToken cancellationToken = default);
    }
}
