using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IEditCustomHostname
    {
        /// <summary>
        /// Modify SSL configuration for a custom hostname. When sent with SSL config that matches existing config,
        /// used to indicate that hostname should pass domain control validation (DCV). Can also be used to change validation type,
        /// e.g., from 'http' to 'email'.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <param name="patchCustomHostname">SSL properties used when creating the custom hostname</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> EditCustomHostnameAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname);

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
        Task<CloudFlareResult<CustomHostname>> EditCustomHostnameAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname, CancellationToken cancellationToken);
    }
}