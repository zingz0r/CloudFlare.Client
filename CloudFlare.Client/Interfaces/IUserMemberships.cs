using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface IUserMemberships
    {
        /// <summary>
        /// Remove the associated member from an account
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> DeleteAsync(string membershipId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="filter">User Memberships filtering options</param>
        /// <param name="displayOptions">Display options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a specific membership
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetDetailsAsync(string membershipId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Accept or reject this account invitation
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="status">Whether to accept or reject this account invitation</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> UpdateAsync(string membershipId, MembershipStatus status, CancellationToken cancellationToken = default);
    }
}