using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetUserDetails
    {
        /// <summary>
        /// The currently logged in/authenticated User
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<User>> GetUserDetailsAsync();

        /// <summary>
        /// The currently logged in/authenticated User
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<User>> GetUserDetailsAsync(CancellationToken cancellationToken);
    }
}