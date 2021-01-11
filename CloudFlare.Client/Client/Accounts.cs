using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
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
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync()
        {
            return await GetAsync(null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(CancellationToken cancellationToken)
        {
            return await GetAsync(null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page)
        {
            return await GetAsync(page, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page, CancellationToken cancellationToken)
        {
            return await GetAsync(page, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page, int? perPage)
        {
            return await GetAsync(page, perPage, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetAsync(page, perPage, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page, int? perPage, OrderType? order)
        {
            return await GetAsync(page, perPage, order, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(int? page, int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;

            return await Connection.GetAsync<IReadOnlyList<Account>>($"{ApiParameter.Endpoints.Account.Base}/?{parameterString}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetDetailsAsync(string accountId)
        {
            return await GetDetailsAsync(accountId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetDetailsAsync(string accountId, CancellationToken cancellationToken)
        {
            return await Connection.GetAsync<IReadOnlyList<Account>>($"{ApiParameter.Endpoints.Account.Base}/?{accountId}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAsync(string accountId,
            string name)
        {
            return await UpdateAsync(accountId, name, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, CancellationToken cancellationToken)
        {
            return await UpdateAsync(accountId, name, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, AccountSettings settings)
        {
            return await UpdateAsync(accountId, name, settings, default).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, AccountSettings settings, CancellationToken cancellationToken)
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
