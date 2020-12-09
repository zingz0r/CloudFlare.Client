using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetRoles
    {
        /// <summary>
        /// Get all available roles for an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRolesAsync(string accountId);

        /// <summary>
        /// Get all available roles for an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRolesAsync(string accountId, CancellationToken cancellationToken);
    }
}