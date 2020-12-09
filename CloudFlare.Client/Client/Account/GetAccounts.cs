using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync()
        {
            return await GetAccountsAsync(null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(CancellationToken cancellationToken)
        {
            return await GetAccountsAsync(null, null, null, cancellationToken).ConfigureAwait(false);
        }


        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page)
        {
            return await GetAccountsAsync(page, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page,
            CancellationToken cancellationToken)
        {
            return await GetAccountsAsync(page, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page,
            int? perPage)
        {
            return await GetAccountsAsync(page, perPage, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page,
            int? perPage, CancellationToken cancellationToken)
        {
            return await GetAccountsAsync(page, perPage, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page,
            int? perPage, OrderType? order)
        {
            return await GetAccountsAsync(page, perPage, order, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page,
            int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;


            return await _httpClient.GetAsync<IEnumerable<Account>>(
                $"{ApiParameter.Endpoints.Account.Base}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}