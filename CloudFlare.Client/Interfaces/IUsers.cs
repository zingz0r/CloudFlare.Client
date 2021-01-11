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
        /// <returns></returns>
        Task<CloudFlareResult<User>> GetDetailsAsync();

        /// <summary>
        /// The currently logged in/authenticated User
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<User>> GetDetailsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Change user data
        /// </summary>
        /// <param name="editedUser">The edited user details</param>
        /// <returns></returns>
        Task<CloudFlareResult<User>> UpdateAsync(User editedUser);

        /// <summary>
        /// Change user data
        /// </summary>
        /// <param name="editedUser">The edited user details</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<User>> UpdateAsync(User editedUser, CancellationToken cancellationToken);

        /// <summary>
        /// Verify API token
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<VerifyToken>> VerifyAsync();

        /// <summary>
        /// Verify API token
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<VerifyToken>> VerifyAsync(CancellationToken cancellationToken);
    }
}