using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface ICustomHostnames
    {
        /// <summary>
        /// Add a new custom hostname and request that an SSL certificate be issued for it. One of three validation methods—http,
        /// cname, email—should be used, with 'http' recommended if the CNAME is already in place (or will be soon). Specifying 'email'
        /// will send an email to the WHOIS contacts on file for the base domain plus hostmaster, postmaster, webmaster, admin, administrator.
        /// Specifying 'cname' will return a CNAME that needs to be placed. If http is used and the domain is not already pointing to the Managed CNAME host,
        /// the PATCH method must be used once it is (to complete validation).
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">The custom hostname that will point to your hostname via CNAME</param>
        /// <param name="ssl">SSL properties used when creating the custom hostname</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> AddAsync(string zoneId, string hostname, CustomHostnameSsl ssl, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete Custom Hostname (and any issued SSL certificates)
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> DeleteAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="filter">Custom Hostname filtering options</param>
        /// <param name="displayOptions">Display options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<CustomHostname>>> GetAsync(string zoneId, CustomHostnameFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all details of the specified custom hostname
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> GetDetailsAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modify SSL configuration for a custom hostname. When sent with SSL config that matches existing config,
        /// used to indicate that hostname should pass domain control validation (DCV). Can also be used to change validation type,
        /// e.g., from 'http' to 'email'.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <param name="patchCustomHostname">SSL properties used when creating the custom hostname</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> UpdateAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname, CancellationToken cancellationToken = default);
    }
}