namespace CloudFlare.Client
{
    public interface ICloudFlareClient : 
        IDeleteMemberships,
        IGetMemberships,
        IGetMembershipDetails,
        IUpdateMembershipStatus,
        IEditUser,
        IGetUserDetails,
        IVerifyToken,
        IGetAccounts,
        IGetAccountDetails,
        IUpdateAccount,
        IAddAccountMember,
        IDeleteAccountMember,
        IGetAccountMembers,
        IGetAccountMemberDetails,
        IUpdateAccountMember,
        IGetAccountSubscriptions,
        IGetRoles,
        IGetRoleDetails,
        IGetZones,
        ICreateZone,
        IEditZone,
        IDeleteZone,
        IGetZoneDetails,
        IPurgeAllFiles,
        IZoneActivation
    {

        //#region DNS Records for a Zone

        //#region CreateDnsRecordAsync

        ///// <summary>
        ///// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content);

        ///// <summary>
        ///// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, CancellationToken cancellationToken);

        ///// <summary>
        ///// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl);

        ///// <summary>
        ///// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
        //    int? ttl, CancellationToken cancellationToken);

        ///// <summary>
        ///// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        ///// <param name="priority">Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
        //    int? ttl, int? priority);

        ///// <summary>
        ///// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        ///// <param name="priority">Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
        //    int? ttl, int? priority, CancellationToken cancellationToken);

        ///// <summary>
        ///// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        ///// <param name="priority">Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set</param>
        ///// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
        //    int? ttl, int? priority, bool? proxied);

        ///// <summary>
        ///// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        ///// <param name="priority">Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set</param>
        ///// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
        //    int? ttl, int? priority, bool? proxied, CancellationToken cancellationToken);

        //#endregion

        //#region DeleteDnsRecordAsync

        ///// <summary>
        ///// Delete DNS record
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="identifier">Identifier of the record</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId, string identifier);

        ///// <summary>
        ///// Delete DNS record
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="identifier">Identifier of the record</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId, string identifier, CancellationToken cancellationToken);

        //#endregion

        //#region ExportDnsRecordsAsync

        ///// <summary>
        ///// Export your BIND config through this endpoint.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId);

        ///// <summary>
        ///// Export your BIND config through this endpoint.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId, CancellationToken cancellationToken);

        //#endregion

        //#region GetDnsRecordsAsync

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
        //    string content, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
        //    string content, int? page);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
        //    string content, int? page, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of DNS records per page</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
        //    string content, int? page, int? perPage);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of DNS records per page</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
        //    string content, int? page, int? perPage, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of DNS records per page</param>
        ///// <param name="order">Field to order records by</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
        //    string content, int? page, int? perPage, OrderType? order);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of DNS records per page</param>
        ///// <param name="order">Field to order records by</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
        //    string content, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of DNS records per page</param>
        ///// <param name="order">Field to order records by</param>
        ///// <param name="match">Whether to match all search requirements or at least one</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
        //    string content, int? page, int? perPage, OrderType? order, bool? match);

        ///// <summary>
        ///// List, search, sort, and filter a zone's DNS records.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="type">DNS record type</param>
        ///// <param name="name">DNS record name</param>
        ///// <param name="content">DNS record content</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of DNS records per page</param>
        ///// <param name="order">Field to order records by</param>
        ///// <param name="match">Whether to match all search requirements or at least one</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
        //    string content, int? page, int? perPage, OrderType? order, bool? match, CancellationToken cancellationToken);

        //#endregion

        //#region GetDnsRecordDetailsAsync

        ///// <summary>
        ///// Get all details of the specified dns record
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="identifier">Identifier of the record</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId, string identifier);

        ///// <summary>
        ///// Get all details of the specified dns record
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="identifier">Identifier of the record</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId, string identifier, CancellationToken cancellationToken);

        //#endregion

        //#region ImportDnsRecordsAsync

        ///// <summary>
        ///// Import your BIND config through this endpoint.
        ///// Notice: SOA DNS record type is not supported by CloudFlare
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="fileInfo">FileInfo of the file</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo);

        ///// <summary>
        ///// Import your BIND config through this endpoint.
        ///// Notice: SOA DNS record type is not supported by CloudFlare
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="fileInfo">FileInfo of the file</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, CancellationToken cancellationToken);

        ///// <summary>
        ///// Import your BIND config through this endpoint.
        ///// Notice: SOA DNS record type is not supported by CloudFlare
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="fileInfo">FileInfo of the file</param>
        ///// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, bool? proxied);

        ///// <summary>
        ///// Import your BIND config through this endpoint.
        ///// Notice: SOA DNS record type is not supported by CloudFlare
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="fileInfo">FileInfo of the file</param>
        ///// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, bool? proxied, CancellationToken cancellationToken);

        //#endregion

        //#region UpdateDnsRecordAsync

        ///// <summary>
        ///// Update DNS record
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="identifier">Identifier of the record</param>
        ///// <param name="type">The new DNS record type</param>
        ///// <param name="name">The new DNS record name</param>
        ///// <param name="content">The new DNS record content</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name, string content);

        ///// <summary>
        ///// Update DNS record
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="identifier">Identifier of the record</param>
        ///// <param name="type">The new DNS record type</param>
        ///// <param name="name">The new DNS record name</param>
        ///// <param name="content">The new DNS record content</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
        //    string content, CancellationToken cancellationToken);

        ///// <summary>
        ///// Update DNS record
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="identifier">Identifier of the record</param>
        ///// <param name="type">The new DNS record type</param>
        ///// <param name="name">The new DNS record name</param>
        ///// <param name="content">The new DNS record content</param>
        ///// <param name="ttl">The new Time to live for DNS record. Value of 1 is 'automatic'</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
        //    string content, int? ttl);

        ///// <summary>
        ///// Update DNS record
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="identifier">Identifier of the record</param>
        ///// <param name="type">The new DNS record type</param>
        ///// <param name="name">The new DNS record name</param>
        ///// <param name="content">The new DNS record content</param>
        ///// <param name="ttl">The new Time to live for DNS record. Value of 1 is 'automatic'</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
        //    string content, int? ttl, CancellationToken cancellationToken);

        ///// <summary>
        ///// Update DNS record
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="identifier">Identifier of the record</param>
        ///// <param name="type">The new DNS record type</param>
        ///// <param name="name">The new DNS record name</param>
        ///// <param name="content">The new DNS record content</param>
        ///// <param name="ttl">The new Time to live for DNS record. Value of 1 is 'automatic'</param>
        ///// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
        //    string content, int? ttl, bool? proxied);

        ///// <summary>
        ///// Update DNS record
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="identifier">Identifier of the record</param>
        ///// <param name="type">The new DNS record type</param>
        ///// <param name="name">The new DNS record name</param>
        ///// <param name="content">The new DNS record content</param>
        ///// <param name="ttl">The new Time to live for DNS record. Value of 1 is 'automatic'</param>
        ///// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
        //    string content, int? ttl, bool? proxied, CancellationToken cancellationToken);

        //#endregion

        //#endregion

        //#region Custom Hostname for a Zone

        //#region CreateCustomHostnameAsync

        ///// <summary>
        ///// Add a new custom hostname and request that an SSL certificate be issued for it. One of three validation methods—http,
        ///// cname, email—should be used, with 'http' recommended if the CNAME is already in place (or will be soon). Specifying 'email'
        ///// will send an email to the WHOIS contacts on file for the base domain plus hostmaster, postmaster, webmaster, admin, administrator.
        ///// Specifying 'cname' will return a CNAME that needs to be placed. If http is used and the domain is not already pointing to the Managed CNAME host,
        ///// the PATCH method must be used once it is (to complete validation).
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">The custom hostname that will point to your hostname via CNAME</param>
        ///// <param name="ssl">SSL properties used when creating the custom hostname</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<CustomHostname>> CreateCustomHostnameAsync(string zoneId, string hostname,
        //    CustomHostnameSsl ssl);

        ///// <summary>
        ///// Add a new custom hostname and request that an SSL certificate be issued for it. One of three validation methods—http,
        ///// cname, email—should be used, with 'http' recommended if the CNAME is already in place (or will be soon). Specifying 'email'
        ///// will send an email to the WHOIS contacts on file for the base domain plus hostmaster, postmaster, webmaster, admin, administrator.
        ///// Specifying 'cname' will return a CNAME that needs to be placed. If http is used and the domain is not already pointing to the Managed CNAME host,
        ///// the PATCH method must be used once it is (to complete validation).
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">The custom hostname that will point to your hostname via CNAME</param>
        ///// <param name="ssl">SSL properties used when creating the custom hostname</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<CustomHostname>> CreateCustomHostnameAsync(string zoneId, string hostname,
        //    CustomHostnameSsl ssl, CancellationToken cancellationToken);

        //#endregion

        //#region GetCustomHostnamesAsync

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page, int? perPage);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
        //    int? perPage, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
        //    int? perPage, CustomHostnameOrderType? type);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
        //    int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <param name="order">Direction to order hostnames</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
        //    int? perPage, CustomHostnameOrderType? type, OrderType? order);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <param name="order">Direction to order hostnames</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
        //    int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <param name="order">Direction to order hostnames</param>
        ///// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
        //    int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <param name="order">Direction to order hostnames</param>
        ///// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
        //    int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
        //    int? perPage);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
        //    int? perPage, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
        //    int? perPage, CustomHostnameOrderType? type);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
        //    int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <param name="order">Direction to order hostnames</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
        //    int? perPage, CustomHostnameOrderType? type, OrderType? order);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <param name="order">Direction to order hostnames</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
        //    int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <param name="order">Direction to order hostnames</param>
        ///// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
        //    int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl);

        ///// <summary>
        ///// List, search, sort, and filter all of your custom hostnames
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        ///// This parameter cannot be used with the 'hostname' parameter</param>
        ///// <param name="page">Page number of paginated results</param>
        ///// <param name="perPage">Number of hostnames per page</param>
        ///// <param name="type">Field to order hostnames by</param>
        ///// <param name="order">Direction to order hostnames</param>
        ///// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
        //    int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken);

        //#endregion

        //#region GetCustomHostnameDetailsAsync

        ///// <summary>
        ///// Get all details of the specified custom hostname
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId"></param>
        ///// <returns></returns>
        //Task<CloudFlareResult<CustomHostname>> GetCustomHostnameDetailsAsync(string zoneId, string customHostnameId);

        ///// <summary>
        ///// Get all details of the specified custom hostname
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId"></param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<CustomHostname>> GetCustomHostnameDetailsAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken);

        //#endregion

        //#region EditCustomHostnameAsync


        ///// <summary>
        ///// Modify SSL configuration for a custom hostname. When sent with SSL config that matches existing config,
        ///// used to indicate that hostname should pass domain control validation (DCV). Can also be used to change validation type,
        ///// e.g., from 'http' to 'email'.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Custom hostname identifier</param>
        ///// <param name="patchCustomHostname">SSL properties used when creating the custom hostname</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<CustomHostname>> EditCustomHostnameAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname);

        ///// <summary>
        ///// Modify SSL configuration for a custom hostname. When sent with SSL config that matches existing config,
        ///// used to indicate that hostname should pass domain control validation (DCV). Can also be used to change validation type,
        ///// e.g., from 'http' to 'email'.
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Custom hostname identifier</param>
        ///// <param name="patchCustomHostname">SSL properties used when creating the custom hostname</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<CustomHostname>> EditCustomHostnameAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname, CancellationToken cancellationToken);

        //#endregion

        //#region DeleteCustomHostnameAsync

        ///// <summary>
        ///// Delete Custom Hostname (and any issued SSL certificates)
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Custom hostname identifier</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<CustomHostname>> DeleteCustomHostnameAsync(string zoneId, string customHostnameId);

        ///// <summary>
        ///// Delete Custom Hostname (and any issued SSL certificates)
        ///// </summary>
        ///// <param name="zoneId">Zone identifier</param>
        ///// <param name="customHostnameId">Custom hostname identifier</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns></returns>
        //Task<CloudFlareResult<CustomHostname>> DeleteCustomHostnameAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken);

        //#endregion

        //#endregion
    }
}
