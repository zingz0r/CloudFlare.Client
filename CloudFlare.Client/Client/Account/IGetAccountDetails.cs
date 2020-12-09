using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetAccountDetails
    {
        /// <summary>
        /// Get information about a specific account that you are a member of
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountDetailsAsync(string accountId);

        /// <summary>
        /// Get information about a specific account that you are a member of
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<Account>>> GetAccountDetailsAsync(string accountId, CancellationToken cancellationToken);
    }
}