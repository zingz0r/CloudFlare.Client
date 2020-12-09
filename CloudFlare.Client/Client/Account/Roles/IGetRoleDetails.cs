using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetRoleDetails
    {
        /// <summary>
        /// Get information about a specific role for an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="roleId">Role identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountRole>> GetRoleDetailsAsync(string accountId, string roleId);

        /// <summary>
        /// Get information about a specific role for an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="roleId">Role identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountRole>> GetRoleDetailsAsync(string accountId, string roleId, CancellationToken cancellationToken);
    }
}