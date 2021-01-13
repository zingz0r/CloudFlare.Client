using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Authentication;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Users;

namespace CloudFlare.Client.Client.Users
{
    public interface IUsers
    {
        public IMemberships Memberships { get; }

        /// <summary>
        /// The currently logged in/authenticated user
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<User>> GetDetailsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Change user data
        /// </summary>
        /// <param name="editedUser">The edited user details</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<User>> UpdateAsync(User editedUser, CancellationToken cancellationToken = default);

        /// <summary>
        /// Verify API token
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<VerifyToken>> VerifyAsync(CancellationToken cancellationToken = default);
    }
}