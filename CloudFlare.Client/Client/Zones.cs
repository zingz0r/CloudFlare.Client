using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Interfaces;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client
{
    public class Zones : ApiContextBase<IConnection>, IZones
    {
        public ICustomHostnames CustomHostnames { get; }
        public IDnsRecords DnsRecords { get; }

        public Zones(IConnection connection) : base(connection)
        {
            CustomHostnames = new CustomHostnames(connection);
            DnsRecords = new DnsRecords(connection);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> AddAsync(string name, ZoneType type, Account account, bool? jumpStart = null, CancellationToken cancellationToken = default)
        {
            var postZone = new PostZone
            {
                Name = name,
                Account = account,
                Type = type,
                JumpStart = jumpStart ?? false
            };

            return await Connection.PostAsync<Zone, PostZone>($"{ApiParameter.Endpoints.Zone.Base}/", postZone, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> CheckActivationAsync(string zoneId, CancellationToken cancellationToken = default)
        {
            return await Connection.PutAsync<Zone, object>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.ActivationCheck}", "", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> DeleteAsync(string zoneId, CancellationToken cancellationToken = default)
        {
            return await Connection.DeleteAsync<Zone>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(ZoneFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Name, filter?.Name)
                .InsertValue(ApiParameter.Filtering.Status, filter?.Status)
                .InsertValue(ApiParameter.Filtering.Match, filter?.Match)
                .InsertValue(ApiParameter.Filtering.Page, displayOptions?.Page)
                .InsertValue(ApiParameter.Filtering.PerPage, displayOptions?.PerPage)
                .InsertValue(ApiParameter.Filtering.Order, displayOptions?.Order);

            var parameterString = parameterBuilder.ParameterCollection;

            return await Connection.GetAsync<IReadOnlyList<Zone>>($"{ApiParameter.Endpoints.Zone.Base}/?{parameterString}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> GetDetailsAsync(string zoneId, CancellationToken cancellationToken = default)
        {
            return await Connection.GetAsync<Zone>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything, CancellationToken cancellationToken = default)
        {
            var content = new Dictionary<string, bool> { { ApiParameter.Outgoing.PurgeEverything, purgeEverything } };

            return await Connection.PostAsync<Zone, Dictionary<string, bool>>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.PurgeCache}", content, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> UpdateAsync(string zoneId, PatchZone patchZone, CancellationToken cancellationToken = default)
        {
            return await Connection.PatchAsync<Zone>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", PatchContentHelper.Create(patchZone), cancellationToken)
                .ConfigureAwait(false);
        }
    }
}