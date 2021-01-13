using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;

namespace CloudFlare.Client.Client.Accounts
{
    public class Roles : ApiContextBase<IConnection>, IRoles
    {
        public Roles(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Role>>> GetAsync(string accountId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Roles}";
            return await Connection.GetAsync<IReadOnlyList<Role>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Role>> GetDetailsAsync(string accountId, string roleId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Roles}/{roleId}";
            return await Connection.GetAsync<Role>(requestUri, cancellationToken).ConfigureAwait(false);
        }
    }
}