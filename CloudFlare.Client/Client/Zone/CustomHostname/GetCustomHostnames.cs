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
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId)
        {
            return await GetCustomHostnamesAsync(zoneId, null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, order, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, order, ssl, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Hostname, hostname)
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