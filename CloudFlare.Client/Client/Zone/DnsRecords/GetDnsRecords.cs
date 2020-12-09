using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId)
        {
            return await GetDnsRecordsAsync(zoneId, null, null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, null, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type)
        {
            return await GetDnsRecordsAsync(zoneId, type, null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, order, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order, bool? match)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, order, match, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order, bool? match, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.DnsRecordType, type)
                .InsertValue(ApiParameter.Filtering.Name, name)
                .InsertValue(ApiParameter.Filtering.Content, content)
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Order, order)
                .InsertValue(ApiParameter.Filtering.Match, match);

            var parameterString = parameterBuilder.ParameterCollection;

            return await _httpClient.GetAsync<IEnumerable<DnsRecord>>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }
    }
}