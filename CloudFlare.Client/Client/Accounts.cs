using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Interfaces;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client
{
    public class Accounts : ApiContextBase<IConnection>, IAccounts
    {
        public IMembers Members { get; }
        public IRoles Roles { get; }
        public ISubscriptions Subscriptions { get; }

        public Accounts(IConnection connection) : base(connection)
        {
            Members = new Members(connection);
            Roles = new Roles(connection);
            Subscriptions = new Subscriptions(connection);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, displayOptions?.Page)
                .InsertValue(ApiParameter.Filtering.PerPage, displayOptions?.PerPage)
                .InsertValue(ApiParameter.Filtering.Direction, displayOptions?.Order);

            var parameterString = parameterBuilder.ParameterCollection;

            return await Connection.GetAsync<IReadOnlyList<Account>>($"{ApiParameter.Endpoints.Account.Base}/?{parameterString}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetDetailsAsync(string accountId, CancellationToken cancellationToken = default)
        {
            return await Connection.GetAsync<IReadOnlyList<Account>>($"{ApiParameter.Endpoints.Account.Base}/?{accountId}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, AccountSettings settings = null, CancellationToken cancellationToken = default)
        {
            var updatedAccount = new Account
            {
                Id = accountId,
                Name = name,
                Settings = settings
            };

            return await Connection.PutAsync<Account, Account>($"{ApiParameter.Endpoints.Account.Base}/{accountId}", updatedAccount, cancellationToken).ConfigureAwait(false);
        }
    }
}
