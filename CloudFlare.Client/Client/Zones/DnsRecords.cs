using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones.DnsRecord;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;

namespace CloudFlare.Client.Client.Zones
{
    public class DnsRecords : ApiContextBase<IConnection>, IDnsRecords
    {
        public DnsRecords(IConnection connection) : base(connection)
        {
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, DnsRecordType type, string name, string content, AdditionalDnsRecordProperties properties = null, CancellationToken cancellationToken = default)
        {
            var dnsRecord = new DnsRecord
            {
                Content = content,
                Type = type,
                Name = name,
                Ttl = properties?.Ttl ?? 1,
                Priority = properties?.Priority ?? 0,
                Proxied = properties?.Proxied
            };

            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}";
            return await Connection.PostAsync(requestUri, dnsRecord, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> DeleteAsync(string zoneId, string identifier, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{identifier}";
            return await Connection.DeleteAsync<DnsRecord>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<string>> ExportAsync(string zoneId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{DnsRecordEndpoints.Export}";
            return await Connection.GetAsync<string>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
        {
            var builder = new ParameterBuilderHelper()
                .InsertValue(Filtering.DnsRecordType, filter?.Type)
                .InsertValue(Filtering.Name, filter?.Name)
                .InsertValue(Filtering.Content, filter?.Content)
                .InsertValue(Filtering.Page, displayOptions?.Page)
                .InsertValue(Filtering.PerPage, displayOptions?.PerPage)
                .InsertValue(Filtering.Order, displayOptions?.Order)
                .InsertValue(Filtering.Match, filter?.Match);

            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/?{builder.ParameterCollection}";
            return await Connection.GetAsync<IReadOnlyList<DnsRecord>>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> GetDetailsAsync(string zoneId, string identifier, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{identifier}";
            return await Connection.GetAsync<DnsRecord>(requestUri, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecordImportResult>> ImportAsync(string zoneId, FileInfo fileInfo, bool? proxied, CancellationToken cancellationToken = default)
        {
            var form = new MultipartFormDataContent
            {
                {
                    new StringContent(proxied.ToString()), Filtering.Proxied
                },
                {
                    new ByteArrayContent(await FileHelper.ReadAsync(fileInfo.FullName, cancellationToken), 0, Convert.ToInt32(fileInfo.Length)), "file", "upload.txt"
                }
            };

            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{DnsRecordEndpoints.Import}";
            return await Connection.PostAsync<DnsRecordImportResult, MultipartFormDataContent>(requestUri, form, cancellationToken).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<DnsRecordScan>> ScanAsync(string zoneId, CancellationToken cancellationToken = default)
        {
            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{DnsRecordEndpoints.Scan}";
            return await Connection.PostAsync<DnsRecordScan>(requestUri, null, cancellationToken).ConfigureAwait(false);
        }


        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateAsync(string zoneId, string identifier, DnsRecordType type, string name, string content,
            ModifiedDnsRecord modifiedDnsRecord = null, CancellationToken cancellationToken = default)
        {
            var modified = new DnsRecord
            {
                Content = content,
                Type = type,
                Name = name,
                Ttl = modifiedDnsRecord?.Ttl ?? 1,
                Proxied = modifiedDnsRecord?.Proxied
            };

            var requestUri = $"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{identifier}";
            return await Connection.PutAsync(requestUri, modified, cancellationToken).ConfigureAwait(false);
        }
    }
}