using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones.FirewallRules;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Helpers;

namespace CloudFlare.Client.Client.Zones
{
    /// <inheritdoc />
    public class FirewallRules : ApiContextBase<IConnection>, IFirewallRules
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirewallRules"/> class
        /// </summary>
        /// <param name="connection">Connection settings</param>
        public FirewallRules(IConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<FirewallRule>>> GetAsync(string zoneId, UnOrderableDisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var builder = new ParameterBuilderHelper()
                .InsertValue(Filtering.Page, displayOptions?.Page)
                .InsertValue(Filtering.PerPage, displayOptions?.PerPage);

            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneEndpoints.FirewallRules}";
            if (builder.ParameterCollection.HasKeys())
            {
                requestUri = $"{requestUri}?{builder.ParameterCollection}";
            }

            return await Connection.GetAsync<IReadOnlyList<FirewallRule>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<FirewallRule>>> GetAsync(string zoneId, string ruleId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneEndpoints.FirewallRules}?id={ruleId}";
            return await Connection.GetAsync<IReadOnlyList<FirewallRule>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<FirewallRule>>> CreateAsync(string zoneId, IEnumerable<FirewallRule> rules, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneEndpoints.FirewallRules}";
            return await Connection.PostAsync(requestUri, rules, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<FirewallRule>> DeleteAsync(string zoneId, string ruleId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneEndpoints.FirewallRules}/{ruleId}";
            return await Connection.DeleteAsync<FirewallRule>(requestUri, cancellationToken).ConfigureAwait(false);
        }
    }
}
