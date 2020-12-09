using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetMembershipDetails
    {
        /// <summary>
        /// Get a specific membership
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipDetailsAsync(string membershipId);

        /// <summary>
        /// Get a specific membership
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipDetailsAsync(string membershipId, CancellationToken cancellationToken);
    }
}