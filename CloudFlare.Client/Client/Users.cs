using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Interfaces;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client
{
    public class Users : ApiContextBase<IConnection>, IUsers
    {
        public IUserMemberships Memberships { get; set; }

        public Users(IConnection connection) : base(connection)
        {
            Memberships = new UserMemberships(connection);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<User>> GetDetailsAsync(CancellationToken cancellationToken = default)
        {
            return await Connection.GetAsync<User>($"{ApiParameter.Endpoints.User.Base}/", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<User>> UpdateAsync(User editedUser, CancellationToken cancellationToken = default)
        {
            return await Connection.PatchAsync<User>($"{ApiParameter.Endpoints.User.Base}/", PatchContentHelper.Create(editedUser), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<VerifyToken>> VerifyAsync(CancellationToken cancellationToken = default)
        {
            return await Connection.GetAsync<VerifyToken>($"{ApiParameter.Endpoints.Tokens.Base}/{ApiParameter.Endpoints.Tokens.Verify}", cancellationToken).ConfigureAwait(false);
        }
    }
}