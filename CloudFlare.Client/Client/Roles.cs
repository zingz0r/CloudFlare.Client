using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Interfaces;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client
{
    public class Roles : ApiContextBase<IConnection>, IRoles
    {
        public Roles(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountRole>>> GetAsync(string accountId, CancellationToken cancellationToken = default)
        {
            return await Connection.GetAsync<IReadOnlyList<AccountRole>>($"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Roles}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountRole>> GetDetailsAsync(string accountId, string roleId, CancellationToken cancellationToken = default)
        {
            return await Connection.GetAsync<AccountRole>($"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Roles}/{roleId}", cancellationToken).ConfigureAwait(false);
        }
    }
}