using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IVerifyToken
    {
        /// <summary>
        /// Verify API token
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<VerifyToken>> VerifyTokenAsync();

        /// <summary>
        /// Verify API token
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<VerifyToken>> VerifyTokenAsync(CancellationToken cancellationToken);
    }
}