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
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client.Zones;

/// <inheritdoc cref="CloudFlare.Client.Client.Zones.IDnsRecords" />
public class DnsRecords : ApiContextBase<IConnection>, IDnsRecords
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DnsRecords"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public DnsRecords(IConnection connection)
        : base(connection)
    {
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, NewDnsRecordBase newDnsRecord, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}");
        return await Connection.PostAsync<DnsRecord, NewDnsRecordBase>(requestUri, newDnsRecord, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<DnsRecord>> DeleteAsync(string zoneId, string identifier, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{identifier}");
        return await Connection.DeleteAsync<DnsRecord>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<string>> ExportAsync(string zoneId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{DnsRecordEndpoints.Export}");
        return await Connection.GetAsync<string>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
    {
        var parameters = new ParameterBuilder()
            .InsertValue(Filtering.DnsRecordType, filter?.Type)
            .InsertValue(Filtering.Name, filter?.Name)
            .InsertValue(Filtering.Content, filter?.Content)
            .InsertValue(Filtering.Page, displayOptions?.Page)
            .InsertValue(Filtering.PerPage, displayOptions?.PerPage)
            .InsertValue(Filtering.Order, displayOptions?.Order)
            .InsertValue(Filtering.Match, filter?.Match);

        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}").AddParameters(parameters);
        return await Connection.GetAsync<IReadOnlyList<DnsRecord>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<DnsRecord>> GetDetailsAsync(string zoneId, string identifier, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{identifier}");
        return await Connection.GetAsync<DnsRecord>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<DnsRecordImport>> ImportAsync(string zoneId, FileInfo fileInfo, bool? proxied, CancellationToken cancellationToken = default)
    {
        var form = new MultipartFormDataContent
        {
            { new StringContent(proxied.ToString()), Filtering.Proxied },
            { new ByteArrayContent(await FileHelper.ReadAsync(fileInfo.FullName, cancellationToken), 0, Convert.ToInt32(fileInfo.Length)), "file", fileInfo.Name }
        };

        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{DnsRecordEndpoints.Import}");
        return await Connection.PostAsync<DnsRecordImport, MultipartFormDataContent>(requestUri, form, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<DnsRecordScan>> ScanAsync(string zoneId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{DnsRecordEndpoints.Scan}");
        return await Connection.PostAsync<DnsRecordScan>(requestUri, null, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<DnsRecord>> UpdateAsync(string zoneId, string identifier, ModifiedDnsRecord modifiedDnsRecord, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{ZoneEndpoints.Base}/{zoneId}/{DnsRecordEndpoints.Base}/{identifier}");
        return await Connection.PutAsync<DnsRecord, ModifiedDnsRecord>(requestUri, modifiedDnsRecord, cancellationToken).ConfigureAwait(false);
    }
}
