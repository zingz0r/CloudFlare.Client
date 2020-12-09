using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content, CancellationToken cancellationToken)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content, int? ttl)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, ttl, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content, int? ttl, CancellationToken cancellationToken)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, ttl, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content, int? ttl, bool? proxied)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, ttl, proxied, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content, int? ttl, bool? proxied, CancellationToken cancellationToken)
        {
            var updatedDnsRecord = new DnsRecord
            {
                Content = content,
                Type = type,
                Name = name,
                Ttl = ttl ?? 1,
                Proxied = proxied
            };

            return await _httpClient.PutAsync<DnsRecord, DnsRecord>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}/", updatedDnsRecord, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}