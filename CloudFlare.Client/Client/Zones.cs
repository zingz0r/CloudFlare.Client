using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
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
        public async Task<CloudFlareResult<Zone>> AddAsync(string name, ZoneType type, Account account)
        {
            return await AddAsync(name, type, account, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> AddAsync(string name, ZoneType type, Account account, CancellationToken cancellationToken)
        {
            return await AddAsync(name, type, account, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> AddAsync(string name, ZoneType type, Account account, bool? jumpStart)
        {
            return await AddAsync(name, type, account, jumpStart, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> AddAsync(string name, ZoneType type, Account account, bool? jumpStart, CancellationToken cancellationToken)
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
        public async Task<CloudFlareResult<Zone>> CheckActivationAsync(string zoneId)
        {
            return await CheckActivationAsync(zoneId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> CheckActivationAsync(string zoneId, CancellationToken cancellationToken)
        {
            return await Connection.PutAsync<Zone, object>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.ActivationCheck}", "", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> DeleteAsync(string zoneId)
        {
            return await DeleteAsync(zoneId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> DeleteAsync(string zoneId, CancellationToken cancellationToken)
        {
            return await Connection.DeleteAsync<Zone>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync()
        {
            return await GetAsync(null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(CancellationToken cancellationToken)
        {
            return await GetAsync(null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name)
        {
            return await GetAsync(name, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, CancellationToken cancellationToken)
        {
            return await GetAsync(name, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, ZoneStatus? status)
        {
            return await GetAsync(name, status, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, ZoneStatus? status, CancellationToken cancellationToken)
        {
            return await GetAsync(name, status, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, ZoneStatus? status, int? page)
        {
            return await GetAsync(name, status, page, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, ZoneStatus? status, int? page, CancellationToken cancellationToken)
        {
            return await GetAsync(name, status, page, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, ZoneStatus? status, int? page, int? perPage)
        {
            return await GetAsync(name, status, page, perPage, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, ZoneStatus? status, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetAsync(name, status, page, perPage, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, ZoneStatus? status, int? page, int? perPage, OrderType? order)
        {
            return await GetAsync(name, status, page, perPage, order, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, ZoneStatus? status, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetAsync(name, status, page, perPage, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, ZoneStatus? status, int? page, int? perPage, OrderType? order, bool? match)
        {
            return await GetAsync(name, status, page, perPage, order, match, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Zone>>> GetAsync(string name, ZoneStatus? status, int? page, int? perPage, OrderType? order, bool? match, CancellationToken cancellationToken)
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

            return await Connection.GetAsync<IReadOnlyList<Zone>>($"{ApiParameter.Endpoints.Zone.Base}/?{parameterString}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> GetDetailsAsync(string zoneId)
        {
            return await GetDetailsAsync(zoneId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> GetDetailsAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await Connection.GetAsync<Zone>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything)
        {
            return await PurgeAllFilesAsync(zoneId, purgeEverything, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything, CancellationToken cancellationToken)
        {
            var content = new Dictionary<string, bool> { { ApiParameter.Outgoing.PurgeEverything, purgeEverything } };

            return await Connection.PostAsync<Zone, Dictionary<string, bool>>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.PurgeCache}", content, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> UpdateAsync(string zoneId, PatchZone patchZone)
        {
            return await UpdateAsync(zoneId, patchZone, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> UpdateAsync(string zoneId, PatchZone patchZone, CancellationToken cancellationToken)
        {
            return await Connection.PatchAsync<Zone>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", PatchContentHelper.Create(patchZone), cancellationToken)
                .ConfigureAwait(false);
        }
    }
}