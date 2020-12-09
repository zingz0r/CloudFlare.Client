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
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, CancellationToken cancellationToken)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl, CancellationToken cancellationToken)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl, int? priority)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, priority, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl, int? priority, CancellationToken cancellationToken)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, priority, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl, int? priority, bool? proxied)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, priority, proxied, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl, int? priority, bool? proxied, CancellationToken cancellationToken)
        {
            var newDnsRecord = new DnsRecord
            {
                Content = content,
                Type = type,
                Name = name,
                Ttl = ttl ?? 1,
                Priority = priority ?? 0,
                Proxied = proxied
            };

            return await _httpClient.PostAsync<DnsRecord, DnsRecord>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/", newDnsRecord, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}