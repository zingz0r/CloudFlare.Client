using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Users;

namespace CloudFlare.Client.Client.Users
{
    /// <summary>
    /// Interface for interacting with users
    /// </summary>
    public interface IUsers
    {
        /// <summary>
        /// Memberships
        /// </summary>
        /// <value>The implementation of the memberships interaction</value>
        public IMemberships Memberships { get; }

        /// <summary>
        /// The currently logged in/authenticated user
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The requested user details</returns>
        Task<CloudFlareResult<User>> GetDetailsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Change user data
        /// </summary>
        /// <param name="editedUser">The edited user details</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated user</returns>
        Task<CloudFlareResult<User>> UpdateAsync(User editedUser, CancellationToken cancellationToken = default);

        /// <summary>
        /// Verify API token
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The verified token details</returns>
        Task<CloudFlareResult<VerifyToken>> VerifyAsync(CancellationToken cancellationToken = default);
    }
}
