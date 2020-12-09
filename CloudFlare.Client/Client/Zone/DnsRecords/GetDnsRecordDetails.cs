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
        public async Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId,
            string identifier)
        {
            return await GetDnsRecordDetailsAsync(zoneId, identifier, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId,
            string identifier, CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<DnsRecord>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}