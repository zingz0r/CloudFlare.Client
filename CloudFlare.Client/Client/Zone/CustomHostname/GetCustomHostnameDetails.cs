using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> GetCustomHostnameDetailsAsync(string zoneId,
            string customHostnameId)
        {
            return await GetCustomHostnameDetailsAsync(zoneId, customHostnameId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> GetCustomHostnameDetailsAsync(string zoneId,
            string customHostnameId, CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<CustomHostname>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}