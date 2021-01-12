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
    public class Subscriptions : ApiContextBase<IConnection>, ISubscriptions
    {
        public Subscriptions(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<AccountSubscription>>> GetAsync(string accountId, CancellationToken cancellationToken = default)
        {
            return await Connection.GetAsync<IReadOnlyList<AccountSubscription>>(
                    $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Subscriptions}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}