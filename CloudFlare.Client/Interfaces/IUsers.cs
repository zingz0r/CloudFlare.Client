using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface IUsers
    {
        public IUserMemberships Memberships { get; }

        /// <summary>
        /// The currently logged in/authenticated User
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