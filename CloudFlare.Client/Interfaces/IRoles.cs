using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface IRoles
    {
        /// <summary>
        /// Get all available roles for an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountRole>>> GetAsync(string accountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information about a specific role for an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="roleId">Role identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountRole>> GetDetailsAsync(string accountId, string roleId, CancellationToken cancellationToken = default);
    }
}