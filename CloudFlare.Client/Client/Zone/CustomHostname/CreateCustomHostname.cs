using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> CreateCustomHostnameAsync(string zoneId,
            string hostname, CustomHostnameSsl ssl)
        {
            return await CreateCustomHostnameAsync(zoneId, hostname, ssl, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> CreateCustomHostnameAsync(string zoneId,
            string hostname, CustomHostnameSsl ssl, CancellationToken cancellationToken)
        {
            var postCustomHostname = new PostCustomHostname
            {
                Hostname = hostname,
                Ssl = ssl
            };

            return await _httpClient.PostAsync<CustomHostname, PostCustomHostname>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}",
                    postCustomHostname, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}