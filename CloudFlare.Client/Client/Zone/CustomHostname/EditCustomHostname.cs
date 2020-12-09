using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> EditCustomHostnameAsync(string zoneId,
            string customHostnameId, PatchCustomHostname patchCustomHostname)
        {
            return await EditCustomHostnameAsync(zoneId, customHostnameId, patchCustomHostname, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> EditCustomHostnameAsync(string zoneId,
            string customHostnameId, PatchCustomHostname patchCustomHostname, CancellationToken cancellationToken)
        {
            return await _httpClient.PatchAsync<CustomHostname>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}",
                    PatchContentHelper.Create(patchCustomHostname), cancellationToken)
                .ConfigureAwait(false);
        }
    }
}