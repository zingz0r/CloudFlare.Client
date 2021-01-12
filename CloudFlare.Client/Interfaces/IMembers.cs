using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface IMembers
    {
        /// <summary>
        /// Add a user to the list of members for this account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="emailAddress">Your contact email address</param>
        /// <param name="roles">Array of roles associated with this member</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> AddAsync(string accountId, string emailAddress, IReadOnlyList<AccountRole> roles, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove a member from an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> DeleteAsync(string accountId, string memberId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="displayOptions">Display Options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information about a specific member of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> GetDetailsAsync(string accountId, string memberId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="settings">Additional settings of the member</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, MemberUpdateSettings settings = null, CancellationToken cancellationToken = default);
    }
}