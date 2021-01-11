using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Interfaces;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client
{
    public class DnsRecords : ApiContextBase<IConnection>, IDnsRecords
    {
        public DnsRecords(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, DnsRecordType type, string name, string content)
        {
            return await AddAsync(zoneId, type, name, content, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, DnsRecordType type, string name, string content, CancellationToken cancellationToken)
        {
            return await AddAsync(zoneId, type, name, content, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl)
        {
            return await AddAsync(zoneId, type, name, content, ttl, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl, CancellationToken cancellationToken)
        {
            return await AddAsync(zoneId, type, name, content, ttl, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl, int? priority)
        {
            return await AddAsync(zoneId, type, name, content, ttl, priority, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl, int? priority, CancellationToken cancellationToken)
        {
            return await AddAsync(zoneId, type, name, content, ttl, priority, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl, int? priority, bool? proxied)
        {
            return await AddAsync(zoneId, type, name, content, ttl, priority, proxied, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl, int? priority, bool? proxied, CancellationToken cancellationToken)
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

            return await Connection.PostAsync<DnsRecord, DnsRecord>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/", newDnsRecord, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> DeleteAsync(string zoneId, string identifier)
        {
            return await DeleteAsync(zoneId, identifier, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> DeleteAsync(string zoneId, string identifier, CancellationToken cancellationToken)
        {
            return await Connection.DeleteAsync<DnsRecord>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}/", cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<string>> ExportAsync(string zoneId)
        {
            return await ExportAsync(zoneId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<string>> ExportAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await Connection.GetAsync<string>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Export}/", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId)
        {
            return await GetAsync(zoneId, null, null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, null, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type)
        {
            return await GetAsync(zoneId, type, null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, type, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name)
        {
            return await GetAsync(zoneId, type, name, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, type, name, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, string content)
        {
            return await GetAsync(zoneId, type, name, content, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, string content, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, type, name, content, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, string content, int? page)
        {
            return await GetAsync(zoneId, type, name, content, page, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, type, name, content, page, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, int? perPage)
        {
            return await GetAsync(zoneId, type, name, content, page, perPage, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, type, name, content, page, perPage, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order)
        {
            return await GetAsync(zoneId, type, name, content, page, perPage, order, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetAsync(zoneId, type, name, content, page, perPage, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order, bool? match)
        {
            return await GetAsync(zoneId, type, name, content, page, perPage, order, match, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order, bool? match, CancellationToken cancellationToken)
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

            return await Connection.GetAsync<IReadOnlyList<DnsRecord>>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> GetDetailsAsync(string zoneId,
            string identifier)
        {
            return await GetDetailsAsync(zoneId, identifier, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> GetDetailsAsync(string zoneId,
            string identifier, CancellationToken cancellationToken)
        {
            return await Connection.GetAsync<DnsRecord>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}", cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsImportResult>> ImportAsync(string zoneId, FileInfo fileInfo)
        {
            return await ImportAsync(zoneId, fileInfo, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsImportResult>> ImportAsync(string zoneId, FileInfo fileInfo, CancellationToken cancellationToken)
        {
            return await ImportAsync(zoneId, fileInfo, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsImportResult>> ImportAsync(string zoneId, FileInfo fileInfo, bool? proxied)
        {
            return await ImportAsync(zoneId, fileInfo, proxied, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsImportResult>> ImportAsync(string zoneId, FileInfo fileInfo, bool? proxied, CancellationToken cancellationToken)
        {
            var form = new MultipartFormDataContent
            {
                {new StringContent(proxied.ToString()), ApiParameter.Filtering.Proxied},
                {
                    new ByteArrayContent(await FileHelper.ReadAsync(fileInfo.FullName, cancellationToken), 0, Convert.ToInt32(fileInfo.Length)), "file", "upload.txt"
                }
            };

            return await Connection.PostAsync<DnsImportResult, MultipartFormDataContent>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Import}/", form, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<DnsRecordScan>> ScanAsync(string zoneId)
        {
            return await ScanAsync(zoneId, default).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<DnsRecordScan>> ScanAsync(string zoneId, CancellationToken cancellationToken)
        {
            return await Connection.PostAsync<DnsRecordScan, object>(
                    $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Scan}/", null, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateAsync(string zoneId, string identifier, DnsRecordType type, string name, string content)
        {
            return await UpdateAsync(zoneId, identifier, type, name, content, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateAsync(string zoneId, string identifier, DnsRecordType type, string name, string content, CancellationToken cancellationToken)
        {
            return await UpdateAsync(zoneId, identifier, type, name, content, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateAsync(string zoneId, string identifier, DnsRecordType type, string name, string content, int? ttl)
        {
            return await UpdateAsync(zoneId, identifier, type, name, content, ttl, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateAsync(string zoneId, string identifier, DnsRecordType type, string name, string content, int? ttl, CancellationToken cancellationToken)
        {
            return await UpdateAsync(zoneId, identifier, type, name, content, ttl, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateAsync(string zoneId, string identifier, DnsRecordType type, string name, string content, int? ttl, bool? proxied)
        {
            return await UpdateAsync(zoneId, identifier, type, name, content, ttl, proxied, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateAsync(string zoneId, string identifier, DnsRecordType type, string name, string content, int? ttl, bool? proxied, CancellationToken cancellationToken)
        {
            var updatedDnsRecord = new DnsRecord
            {
                Content = content,
                Type = type,
                Name = name,
                Ttl = ttl ?? 1,
                Proxied = proxied
            };

            return await Connection.PutAsync<DnsRecord, DnsRecord>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}/", updatedDnsRecord, cancellationToken)
                .ConfigureAwait(false);
        }
    }
}