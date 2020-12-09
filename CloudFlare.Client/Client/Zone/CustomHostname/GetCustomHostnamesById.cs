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
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, order, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, order, ssl, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Id, customHostnameId)
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Order, type)
                .InsertValue(ApiParameter.Filtering.Direction, order)
                .InsertValue(ApiParameter.Filtering.Ssl, ssl ?? false ? 1 : 0);

            var parameterString = parameterBuilder.ParameterCollection;

            return await _httpClient.GetAsync<IEnumerable<CustomHostname>>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}