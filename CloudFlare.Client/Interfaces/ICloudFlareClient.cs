using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CloudFlare.Client.Api.DnsRecord;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Interfaces
{
    public interface ICloudFlareClient : IDisposable
    {
        #region Zone

        #region CreateZoneAsync

        /// <summary>
        /// Create a new zone
        /// </summary>
        /// <param name="name">The domain name</param>
        /// <param name="type">Zone type</param>
        /// <param name="account">Information about the account the zone belongs to</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account);

        /// <summary>
        /// Create a new zone
        /// </summary>
        /// <param name="name">The domain name</param>
        /// <param name="type">Zone type</param>
        /// <param name="account">Information about the account the zone belongs to</param>
        /// <param name="jumpStart">Automatically attempt to fetch existing DNS records</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account, bool? jumpStart);

        #endregion

        #region EditZoneAsync

        /// <summary>
        /// Only one zone property can be changed at a time
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId);

        /// <summary>
        /// Only one zone property can be changed at a time
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="paused">Indicates if the zone is only using CloudFlare DNS services. A true value means the zone will not receive security or performance benefits.</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId, bool? paused);

        /// <summary>
        /// Only one zone property can be changed at a time
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="paused">Indicates if the zone is only using CloudFlare DNS services. A true value means the zone will not receive security or performance benefits.</param>
        /// <param name="vanityNameServers">An array of domains used for custom name servers. This is only available for Business and Enterprise plans.</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId, bool? paused, IEnumerable<string> vanityNameServers);

        /// <summary>
        /// Only one zone property can be changed at a time
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="paused">Indicates if the zone is only using CloudFlare DNS services. A true value means the zone will not receive security or performance benefits.</param>
        /// <param name="vanityNameServers">An array of domains used for custom name servers. This is only available for Business and Enterprise plans.</param>
        /// <param name="planId">The desired plan for the zone. Changing this value will create/cancel associated subscriptions. To view available plans for this zone, see Zone Plans</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId, bool? paused, IEnumerable<string> vanityNameServers, int? planId);

        #endregion

        #region GetZonesAsync

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync();

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus status);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus status, int page);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus status, int page,
            int perPage);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus status, int page,
            int perPage, OrderType order);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="match">Whether to match all search requirements or at least one</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage, OrderType? order, bool? match);

        #endregion

        #region GetZoneDetailsAsync

        /// <summary>
        /// Get all details of the specified zone
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> GetZoneDetailsAsync(string zoneId);

        #endregion

        #endregion

        #region DNS Records for a Zone

        #region CreateDnsRecordAsync

        /// <summary>
        /// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content);

        /// <summary>
        /// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
            int? ttl);

        /// <summary>
        /// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        /// <param name="priority">Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
            int? ttl, int? priority);

        /// <summary>
        /// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        /// <param name="priority">Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set</param>
        /// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
            int? ttl, int? priority, bool? proxied);

        #endregion

        #region DeleteDnsRecordAsync

        /// <summary>
        /// Delete DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId, string identifier);

        #endregion

        #region ExportDnsRecordsAsync

        /// <summary>
        /// Export your BIND config through this endpoint.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<string> ExportDnsRecordsAsync(string zoneId);

        #endregion

        #region GetDnsRecordsAsync

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
            string content);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
            string content, int? page);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
            string content, int? page, int? perPage);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
            string content, int? page, int? perPage, OrderType? order);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
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
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
            string content, int? page, int? perPage, OrderType? order, bool? match);

        #endregion

        #region GetDnsRecordDetailsAsync

        /// <summary>
        /// Get all details of the specified dns record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId, string identifier);

        #endregion

        #region ImportDnsRecordsAsync

        /// <summary>
        /// Import your BIND config through this endpoint.
        /// Notice: SOA DNS record type is not supported by CloudFlare
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="fileInfo">FileInfo of the file</param>
        /// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        /// <returns></returns>
        Task<CloudFlareResult<ImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, bool? proxied = null);

        #endregion

        #region UpdateDnsRecordAsync

        /// <summary>
        /// Update DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <param name="type">The new DNS record type</param>
        /// <param name="name">The new DNS record name</param>
        /// <param name="content">The new DNS record content</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
            string content);

        /// <summary>
        /// Update DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <param name="type">The new DNS record type</param>
        /// <param name="name">The new DNS record name</param>
        /// <param name="content">The new DNS record content</param>
        /// <param name="ttl">The new Time to live for DNS record. Value of 1 is 'automatic'</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
            string content, int? ttl);

        /// <summary>
        /// Update DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <param name="type">The new DNS record type</param>
        /// <param name="name">The new DNS record name</param>
        /// <param name="content">The new DNS record content</param>
        /// <param name="ttl">The new Time to live for DNS record. Value of 1 is 'automatic'</param>
        /// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
            string content, int? ttl, bool? proxied);

        #endregion

        #endregion
    }
}