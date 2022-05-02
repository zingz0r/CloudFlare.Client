using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones.FirewallRules;
using CloudFlare.Client.Contexts;

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
        public async Task<CloudFlareResult<IEnumerable<FirewallRule>>> GetFirewallRulesAsync(string zoneId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneEndpoints.FirewallRules}";
            return await Connection.GetAsync<IEnumerable<FirewallRule>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<FirewallRule>> GetFirewallRuleAsync(string zoneId, string id, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneEndpoints.FirewallRules}?id={id}";
            return await Connection.GetAsync<FirewallRule>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<FirewallRule>>> CreateFirewallRulesAsync(string zoneId, IEnumerable<FirewallRule> rules, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneEndpoints.FirewallRules}";
            return await Connection.PostAsync(requestUri, rules, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<FirewallRule>> DeleteFirewallRuleAsync(string zoneId, string ruleId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{ZoneEndpoints.FirewallRules}/{ruleId}";
            return await Connection.DeleteAsync<FirewallRule>(requestUri, cancellationToken).ConfigureAwait(false);
        }
    }
}
