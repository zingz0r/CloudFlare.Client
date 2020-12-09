using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface ICreateCustomHostname
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
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> CreateCustomHostnameAsync(string zoneId, string hostname,
            CustomHostnameSsl ssl);

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
        Task<CloudFlareResult<CustomHostname>> CreateCustomHostnameAsync(string zoneId, string hostname,
            CustomHostnameSsl ssl, CancellationToken cancellationToken);
    }
}