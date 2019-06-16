using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface ICloudFlareClient
    {
        #region User

        #region GetUserDetailsAsync

        /// <summary>
        /// Change user data
        /// </summary>
        /// <param name="editedUser">The edited user details</param>
        /// <returns></returns>
        Task<CloudFlareResult<User>> EditUserAsync(User editedUser);

        #endregion

        #region GetUserDetailsAsync

        /// <summary>
        /// The currently logged in/authenticated User
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<User>> GetUserDetailsAsync();

        #endregion

        #endregion

        #region User's Account Memberships

        #region DeleteMembershipAsync

        /// <summary>
        /// Remove the associated member from an account
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> DeleteMembershipAsync(string membershipId);

        #endregion

        #region GetMembershipsAsync

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync();

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <param name="membershipOrder">Field to order memberships by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage, MembershipOrder? membershipOrder);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <param name="membershipOrder">Field to order memberships by</param>
        /// <param name="order">Direction to order memberships</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage, MembershipOrder? membershipOrder, OrderType? order);

        #endregion

        #region GetMembershipDetailsAsync

        /// <summary>
        /// Get a specific membership
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipDetailsAsync(string membershipId);

        #endregion

        #region UpdateMembershipAsync

        /// <summary>
        /// Accept or reject this account invitation
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="status">Whether to accept or reject this account invitation</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> UpdateMembershipStatusAsync(string membershipId, SetMembershipStatus status);

        #endregion

        #endregion

        #region Accounts

        #region GetAccountsAsync

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync();

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page, int? perPage);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page, int? perPage, OrderType? order);

        #endregion

        #region GetAccountDetailsAsync

        /// <summary>
        /// Get information about a specific account that you are a member of
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Account>>> GetAccountDetailsAsync(string accountId);

        #endregion

        #region UpdateAccount

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="settings">Account settings</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name, AccountSettings settings);

        #endregion

        #endregion

        #region Account Members

        #region AddAccountMemberAsync

        /// <summary>
        /// Add a user to the list of members for this account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="emailAddress">Your contact email address</param>
        /// <param name="roles">Array of roles associated with this member</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> AddAccountMemberAsync(string accountId, string emailAddress, IEnumerable<AccountRole> roles);

        #endregion

        #region DeleteAccountMemberAsync

        /// <summary>
        /// Remove a member from an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> DeleteAccountMemberAsync(string accountId, string memberId);

        #endregion

        #region GetAccountMembersAsync

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage, OrderType? order);

        #endregion

        #region GetAccountMemberDetailsAsync

        /// <summary>
        /// Get information about a specific member of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> GetAccountMemberDetailsAsync(string accountId, string memberId);

        #endregion

        #region UpdateAccountMemberAsync

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <param name="user">User object</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code, User user);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <param name="user">User object</param>
        /// <param name="status">A member's status in the account</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code, User user, MembershipStatus? status);

        #endregion

        #endregion

        #region Account Subscriptions

        #region GetAccountSubscriptionsAsync

        /// <summary>
        /// Lists all an account's subscriptions
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountSubscription>>> GetAccountSubscriptionsAsync(string accountId);

        #endregion

        #endregion

        #region Roles

        #region GetRolesAsync

        /// <summary>
        /// Get all available roles for an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRolesAsync(string accountId);

        #endregion

        #region GetRoleDetailsAsync

        /// <summary>
        /// Get information about a specific role for an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="roleId">Role identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRoleDetailsAsync(string accountId, string roleId);

        #endregion

        #endregion

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

        #region DeleteZoneAsync

        /// <summary>
        /// Delete DNS zone
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> DeleteZoneAsync(string zoneId);

        #endregion

        #region EditZoneAsync

        /// <summary>
        /// Change key zone property with new value 
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="patchZone">The modified zone values</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId, PatchZone patchZone);

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
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage, OrderType? order);

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

        #region PurgeAllFilesAsync

        /// <summary>
        /// Remove ALL files from CloudFlare's cache
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="purgeEverything">A flag that indicates all resources in CloudFlare's cache should be removed. Note: This may have dramatic affects on your origin server load after performing this action.</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything);

        #endregion

        #region ZoneActivationCheckAsync

        /// <summary>
        /// Initiate another zone activation check
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> ZoneActivationCheckAsync(string zoneId);

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
        Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId);

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
        /// <returns></returns>
        Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo);

        /// <summary>
        /// Import your BIND config through this endpoint.
        /// Notice: SOA DNS record type is not supported by CloudFlare
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="fileInfo">FileInfo of the file</param>
        /// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, bool? proxied);

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