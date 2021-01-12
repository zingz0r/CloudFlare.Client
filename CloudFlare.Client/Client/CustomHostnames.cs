using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
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
        public async Task<CloudFlareResult<CustomHostname>> AddAsync(string zoneId, string hostname, CustomHostnameSsl ssl, CancellationToken cancellationToken = default)
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
        public async Task<CloudFlareResult<CustomHostname>> DeleteAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken = default)
        {
            return await Connection.DeleteAsync<CustomHostname>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, CustomHostnameFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Id, filter?.CustomHostnameId)
                .InsertValue(ApiParameter.Filtering.Hostname, filter?.Hostname)
                .InsertValue(ApiParameter.Filtering.Order, filter?.OrderType)
                .InsertValue(ApiParameter.Filtering.Ssl, filter?.Ssl ?? false ? 1 : 0)
                .InsertValue(ApiParameter.Filtering.Page, displayOptions?.Page)
                .InsertValue(ApiParameter.Filtering.PerPage, displayOptions?.PerPage)
                .InsertValue(ApiParameter.Filtering.Direction, displayOptions?.Order);

            var parameterString = parameterBuilder.ParameterCollection;

            return await Connection.GetAsync<IReadOnlyList<CustomHostname>>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> GetDetailsAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken = default)
        {
            return await Connection.GetAsync<CustomHostname>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> UpdateAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname, CancellationToken cancellationToken = default)
        {
            return await Connection.PatchAsync<CustomHostname>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}", PatchContentHelper.Create(patchCustomHostname), cancellationToken)
                .ConfigureAwait(false);
        }
    }
}