using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones.FirewallRules;

namespace CloudFlare.Client.Client.Zones
{
    /// <summary>
    /// Interface for interacting with zone firewall rules
    /// </summary>
    public interface IFirewallRules
    {
        /// <summary>
        /// Get Firewall Rules
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Firewall rules</returns>
        Task<CloudFlareResult<IReadOnlyList<FirewallRule>>> GetAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Firewall Rule By Id
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// /// <param name="ruleId">Firewall rule identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Firewall rule</returns>
        Task<CloudFlareResult<IReadOnlyList<FirewallRule>>> GetAsync(string zoneId, string ruleId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create Firewall Rules
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// /// <param name="rules">List of firewall rules</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Created firewall rules</returns>
        Task<CloudFlareResult<IEnumerable<FirewallRule>>> CreateAsync(string zoneId, IEnumerable<FirewallRule> rules, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete Firewall Rule By Id
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="ruleId">Firewall rule identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Deleted firewall rule</returns>
        Task<CloudFlareResult<FirewallRule>> DeleteAsync(string zoneId, string ruleId, CancellationToken cancellationToken = default);
    }
}
