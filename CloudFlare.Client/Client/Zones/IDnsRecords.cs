using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones.DnsRecord;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Client.Zones
{
    public interface IDnsRecords
    {
        /// <summary>
        /// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="properties">Properties of the DNS Record</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> AddAsync(string zoneId, DnsRecordType type, string name, string content, AdditionalDnsRecordProperties properties = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> DeleteAsync(string zoneId, string identifier, CancellationToken cancellationToken = default);

        /// <summary>
        /// Export your BIND config through this endpoint.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<string>> ExportAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="filter">DNS Records filtering options</param>
        /// <param name="displayOptions">Display options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<DnsRecord>>> GetAsync(string zoneId, DnsRecordFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all details of the specified dns record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> GetDetailsAsync(string zoneId, string identifier, CancellationToken cancellationToken = default);

        /// <summary>
        /// Import your BIND config through this endpoint.
        /// Notice: SOA DNS record type is not supported by CloudFlare
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="fileInfo">FileInfo of the file</param>
        /// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecordImportResult>> ImportAsync(string zoneId, FileInfo fileInfo, bool? proxied, CancellationToken cancellationToken = default);

        /// <summary>
        /// Scan for DNS DnsRecordEndpoints, alternative to jump_start option
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecordScan>> ScanAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <param name="type">The new DNS record type</param>
        /// <param name="name">The new DNS record name</param>
        /// <param name="content">The new DNS record content</param>
        /// <param name="modifiedDnsRecord">Modified DNS Record</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> UpdateAsync(string zoneId, string identifier, DnsRecordType type, string name,
            string content, ModifiedDnsRecord modifiedDnsRecord = null, CancellationToken cancellationToken = default);
    }
}