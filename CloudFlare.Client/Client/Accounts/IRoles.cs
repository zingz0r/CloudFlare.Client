using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Client.Accounts
{
    public interface IRoles
    {
        /// <summary>
        /// Get all available roles for an account
        /// </summary>
        /// <param name="accountId">AccountEndpoints identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Role>>> GetAsync(string accountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get information about a specific role for an account
        /// </summary>
        /// <param name="accountId">AccountEndpoints identifier tag</param>
        /// <param name="roleId">Role identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Role>> GetDetailsAsync(string accountId, string roleId, CancellationToken cancellationToken = default);
    }
}