using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface ICloudFlareClient
    {
        /// <summary>
        /// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        /// <param name="priority">Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set</param>
        /// <param name="proxied">Whether the record is receiving the performance and security benefits of Cloudflare</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl = null, int? priority = null, bool? proxied = null);

        /// <summary>
        /// Delete DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId, string identifier);

        /// <summary>
        /// You can export your BIND config through this endpoint.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<string> ExportDnsRecordsAsync(string zoneId);

        /// <summary>
        /// List, search, sort, and filter a zones' DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="match">Whether to match all search requirements or at least one</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type = null, string name = "", string content = "", int? page = null, int? perPage = null, OrderType? order = null, bool? match = null);

        /// <summary>
        /// Get all details of the specified dns record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId, string identifier);

        /// <summary>
        /// Update DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <param name="type">The new DNS record type</param>
        /// <param name="name">The new DNS record name</param>
        /// <param name="content">The new DNS record content</param>
        /// <param name="ttl">The new Time to live for DNS record. Value of 1 is 'automatic'</param>
        /// <param name="proxied">Whether the record is receiving the performance and security benefits of Cloudflare</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name, string content, int? ttl = null, bool? proxied = null);
    }
}