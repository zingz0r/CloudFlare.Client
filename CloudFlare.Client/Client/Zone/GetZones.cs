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
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync()
        {
            return await GetZonesAsync(null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(CancellationToken cancellationToken)
        {
            return await GetZonesAsync(null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name)
        {
            return await GetZonesAsync(name, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            CancellationToken cancellationToken)
        {
            return await GetZonesAsync(name, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status)
        {
            return await GetZonesAsync(name, status, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, CancellationToken cancellationToken)
        {
            return await GetZonesAsync(name, status, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page)
        {
            return await GetZonesAsync(name, status, page, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, CancellationToken cancellationToken)
        {
            return await GetZonesAsync(name, status, page, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage)
        {
            return await GetZonesAsync(name, status, page, perPage, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetZonesAsync(name, status, page, perPage, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage, OrderType? order)
        {
            return await GetZonesAsync(name, status, page, perPage, order, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetZonesAsync(name, status, page, perPage, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage, OrderType? order, bool? match)
        {
            return await GetZonesAsync(name, status, page, perPage, order, match, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage, OrderType? order, bool? match, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Name, name)
                .InsertValue(ApiParameter.Filtering.Status, status)
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Order, order)
                .InsertValue(ApiParameter.Filtering.Match, match);

            var parameterString = parameterBuilder.ParameterCollection;

            return await _httpClient.GetAsync<IReadOnlyList<Zone>>(
                $"{ApiParameter.Endpoints.Zone.Base}/?{parameterString}", cancellationToken).ConfigureAwait(false);
        }
    }
}