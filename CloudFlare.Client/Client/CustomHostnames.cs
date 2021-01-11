using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Interfaces;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client
{
    public class CustomHostnames : ApiContextBase<IConnection>, ICustomHostnames
    {
        public CustomHostnames(IConnection connection) : base(connection)
        {

        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> AddAsync(string zoneId, string hostname, CustomHostnameSsl ssl)
        {
            return await AddAsync(zoneId, hostname, ssl, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> AddAsync(string zoneId, string hostname, CustomHostnameSsl ssl, CancellationToken cancellationToken)
        {
            var postCustomHostname = new PostCustomHostname
            {
                Hostname = hostname,
                Ssl = ssl
            };

            return await Connection.PostAsync<CustomHostname, PostCustomHostname>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}", postCustomHostname, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> DeleteAsync(string zoneId, string customHostnameId)
        {
            return await DeleteAsync(zoneId, customHostnameId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> DeleteAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken)
        {
            return await Connection.DeleteAsync<CustomHostname>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId)
        {
            return await GetAsync(zoneId, null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname)
        {
            return await GetAsync(zoneId, hostname, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, hostname, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page)
        {
            return await GetAsync(zoneId, hostname, page, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, hostname, page, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage)
        {
            return await GetAsync(zoneId, hostname, page, perPage, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, hostname, page, perPage, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type)
        {
            return await GetAsync(zoneId, hostname, page, perPage, type, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, hostname, page, perPage, type, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order)
        {
            return await GetAsync(zoneId, hostname, page, perPage, type, order, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, hostname, page, perPage, type, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl)
        {
            return await GetAsync(zoneId, hostname, page, perPage, type, order, ssl, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken)
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

            return await Connection.GetAsync<IReadOnlyList<CustomHostname>>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId)
        {
            return await GetByIdAsync(zoneId, null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(zoneId, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId)
        {
            return await GetByIdAsync(zoneId, customHostnameId, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(zoneId, customHostnameId, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page)
        {
            return await GetByIdAsync(zoneId, customHostnameId, page, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(zoneId, customHostnameId, page, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage)
        {
            return await GetByIdAsync(zoneId, customHostnameId, page, perPage, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(zoneId, customHostnameId, page, perPage, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type)
        {
            return await GetByIdAsync(zoneId, customHostnameId, page, perPage, type, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(zoneId, customHostnameId, page, perPage, type, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order)
        {
            return await GetByIdAsync(zoneId, customHostnameId, page, perPage, type, order, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetByIdAsync(zoneId, customHostnameId, page, perPage, type, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl)
        {
            return await GetByIdAsync(zoneId, customHostnameId, page, perPage, type, order, ssl, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken)
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

            return await Connection.GetAsync<IReadOnlyList<CustomHostname>>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> GetDetailsAsync(string zoneId,
            string customHostnameId)
        {
            return await GetDetailsAsync(zoneId, customHostnameId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> GetDetailsAsync(string zoneId,
            string customHostnameId, CancellationToken cancellationToken)
        {
            return await Connection.GetAsync<CustomHostname>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> UpdateAsync(string zoneId,
            string customHostnameId, PatchCustomHostname patchCustomHostname)
        {
            return await UpdateAsync(zoneId, customHostnameId, patchCustomHostname, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> UpdateAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname, CancellationToken cancellationToken)
        {
            return await Connection.PatchAsync<CustomHostname>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}", PatchContentHelper.Create(patchCustomHostname), cancellationToken)
                .ConfigureAwait(false);
        }
    }
}