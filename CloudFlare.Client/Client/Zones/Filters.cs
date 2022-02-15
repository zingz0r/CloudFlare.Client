using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones.Filters;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Helpers;

namespace CloudFlare.Client.Client.Zones
{
    /// <inheritdoc />
    public class Filters : ApiContextBase<IConnection>, IFilters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Filters"/> class
        /// </summary>
        /// <param name="connection">Connection settings</param>
        public Filters(IConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Filter>>> GetAsync(string zoneId, FilterRequestFilter filter = null, UnOrderableDisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var builder = new ParameterBuilderHelper()
                          .InsertValue(Filtering.Id, filter?.Id)
                          .InsertValue(Filtering.Paused, filter?.Paused)
                          .InsertValue(Filtering.Expression, filter?.Expression)
                          .InsertValue(Filtering.Description, filter?.Description)
                          .InsertValue(Filtering.Ref, filter?.Ref)
                          .InsertValue(Filtering.Page, displayOptions?.Page)
                          .InsertValue(Filtering.PerPage, displayOptions?.PerPage);

            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{FilterEndpoints.Base}";
            if (builder.ParameterCollection.HasKeys())
            {
                requestUri = $"{requestUri}/?{builder.ParameterCollection}";
            }

            return await Connection.GetAsync<IReadOnlyList<Filter>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Filter>> GetDetailsAsync(string zoneId, string identifier, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{FilterEndpoints.Base}/{identifier}";
            return await Connection.GetAsync<Filter>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Filter>>> PostAsync(string zoneId, IReadOnlyList<Filter> filters, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{FilterEndpoints.Base}";
            return await Connection.PostAsync<IReadOnlyList<Filter>, IReadOnlyList<Filter>>(requestUri, filters, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Filter>> UpdateAsync(string zoneId, string identifier, Filter filter, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{FilterEndpoints.Base}/{identifier}";
            return await Connection.PutAsync<Filter, Filter>(requestUri, filter, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Filter>>> UpdateAsync(string zoneId, IReadOnlyList<Filter> filters, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{FilterEndpoints.Base}";
            return await Connection.PutAsync<IReadOnlyList<Filter>, IReadOnlyList<Filter>>(requestUri, filters, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<Filter>>> DeleteAsync(string zoneId, IEnumerable<string> identifiers, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{FilterEndpoints.Base}";
            return await Connection.DeleteAsync<IReadOnlyList<Filter>, IReadOnlyList<dynamic>>(requestUri, identifiers.Select(x => new { id = x }).ToArray(), cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Filter>> DeleteAsync(string zoneId, string identifier, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{FilterEndpoints.Base}/{identifier}";
            return await Connection.DeleteAsync<Filter>(requestUri, cancellationToken).ConfigureAwait(false);
        }
    }
}
