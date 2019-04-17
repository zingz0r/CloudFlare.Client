using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface ICloudFlareClient
    {
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
    }
}