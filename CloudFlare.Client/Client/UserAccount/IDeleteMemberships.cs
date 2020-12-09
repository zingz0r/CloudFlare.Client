using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IDeleteMemberships
    {
        /// <summary>
        /// Remove the associated member from an account
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> DeleteMembershipAsync(string membershipId);

        /// <summary>
        /// Remove the associated member from an account
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> DeleteMembershipAsync(string membershipId, CancellationToken cancellationToken);
    }
}