using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface ICloudFlareClient
    {
        #region User

        #region EditUserAsync

        /// <summary>
        /// Change user data
        /// </summary>
        /// <param name="editedUser">The edited user details</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<User>> EditUserAsync(User editedUser, CancellationToken cancellationToken = default);

        #endregion

        #region GetUserDetailsAsync

        /// <summary>
        /// The currently logged in/authenticated User
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<User>> GetUserDetailsAsync(CancellationToken cancellationToken = default);

        #endregion

        #region VerifyTokenAsync

        /// <summary>
        /// Verify API token
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<VerifyToken>> VerifyTokenAsync(CancellationToken cancellationToken = default);

        #endregion

        #endregion

        #region User's Account Memberships

        #region DeleteMembershipAsync

        /// <summary>
        /// Remove the associated member from an account
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> DeleteMembershipAsync(string membershipId, CancellationToken cancellationToken = default);

        #endregion

        #region GetMembershipsAsync

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, CancellationToken cancellationToken = default);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, CancellationToken cancellationToken = default);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page, CancellationToken cancellationToken = default);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage, CancellationToken cancellationToken = default);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <param name="membershipOrder">Field to order memberships by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage, MembershipOrder? membershipOrder, CancellationToken cancellationToken = default);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <param name="membershipOrder">Field to order memberships by</param>
        /// <param name="order">Direction to order memberships</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage, MembershipOrder? membershipOrder, OrderType? order, CancellationToken cancellationToken = default);

        #endregion

        #region GetMembershipDetailsAsync

        /// <summary>
        /// Get a specific membership
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipDetailsAsync(string membershipId, CancellationToken cancellationToken = default);

        #endregion

        #region UpdateMembershipAsync

        /// <summary>
        /// Accept or reject this account invitation
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="status">Whether to accept or reject this account invitation</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<UserMembership>>> UpdateMembershipStatusAsync(string membershipId, SetMembershipStatus status, CancellationToken cancellationToken = default);

        #endregion

        #endregion

        #region Accounts

        #region GetAccountsAsync

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page, CancellationToken cancellationToken = default);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page, int? perPage, CancellationToken cancellationToken = default);

        /// <summary>
        /// List all accounts you have ownership or verified access to
        /// </summary>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page, int? perPage, OrderType? order, CancellationToken cancellationToken = default);

        #endregion

        #region GetAccountDetailsAsync

        /// <summary>
        /// Get information about a specific account that you are a member of
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Account>>> GetAccountDetailsAsync(string accountId, CancellationToken cancellationToken = default);

        #endregion

        #region UpdateAccount

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update an existing Account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="name">Account name</param>
        /// <param name="settings">Account settings</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name, AccountSettings settings, CancellationToken cancellationToken = default);

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
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> AddAccountMemberAsync(string accountId, string emailAddress, IEnumerable<AccountRole> roles, CancellationToken cancellationToken = default);

        #endregion

        #region DeleteAccountMemberAsync

        /// <summary>
        /// Remove a member from an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> DeleteAccountMemberAsync(string accountId, string memberId, CancellationToken cancellationToken = default);

        #endregion

        #region GetAccountMembersAsync

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, CancellationToken cancellationToken = default);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage, CancellationToken cancellationToken = default);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken = default);

        #endregion

        #region GetAccountMemberDetailsAsync

        /// <summary>
        /// Get information about a specific member of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> GetAccountMemberDetailsAsync(string accountId, string memberId, CancellationToken cancellationToken = default);

        #endregion

        #region UpdateAccountMemberAsync

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <param name="user">User object</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code, User user, CancellationToken cancellationToken = default);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <param name="user">User object</param>
        /// <param name="status">A member's status in the account</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code, User user, MembershipStatus? status, CancellationToken cancellationToken = default);

        #endregion

        #endregion

        #region Account Subscriptions

        #region GetAccountSubscriptionsAsync

        /// <summary>
        /// Lists all an account's subscriptions
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountSubscription>>> GetAccountSubscriptionsAsync(string accountId, CancellationToken cancellationToken = default);

        #endregion

        #endregion

        #region Roles

        #region GetRolesAsync

        /// <summary>
        /// Get all available roles for an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRolesAsync(string accountId, CancellationToken cancellationToken = default);

        #endregion

        #region GetRoleDetailsAsync

        /// <summary>
        /// Get information about a specific role for an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="roleId">Role identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountRole>> GetRoleDetailsAsync(string accountId, string roleId, CancellationToken cancellationToken = default);

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
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new zone
        /// </summary>
        /// <param name="name">The domain name</param>
        /// <param name="type">Zone type</param>
        /// <param name="account">Information about the account the zone belongs to</param>
        /// <param name="jumpStart">Automatically attempt to fetch existing DNS records</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account, bool? jumpStart, CancellationToken cancellationToken = default);

        #endregion

        #region DeleteZoneAsync

        /// <summary>
        /// Delete DNS zone
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> DeleteZoneAsync(string zoneId, CancellationToken cancellationToken = default);

        #endregion

        #region EditZoneAsync

        /// <summary>
        /// Change key zone property with new value 
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="patchZone">The modified zone values</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId, PatchZone patchZone, CancellationToken cancellationToken = default);

        #endregion

        #region GetZonesAsync

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage, OrderType? order, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter zones
        /// </summary>
        /// <param name="name">A domain name</param>
        /// <param name="status">Status of the zone</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="match">Whether to match all search requirements or at least one</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page,
            int? perPage, OrderType? order, bool? match, CancellationToken cancellationToken = default);

        #endregion

        #region GetZoneDetailsAsync

        /// <summary>
        /// Get all details of the specified zone
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> GetZoneDetailsAsync(string zoneId, CancellationToken cancellationToken = default);

        #endregion

        #region PurgeAllFilesAsync

        /// <summary>
        /// Remove ALL files from CloudFlare's cache
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="purgeEverything">A flag that indicates all resources in CloudFlare's cache should be removed. Note: This may have dramatic affects on your origin server load after performing this action.</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything, CancellationToken cancellationToken = default);

        #endregion

        #region ZoneActivationCheckAsync

        /// <summary>
        /// Initiate another zone activation check
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> ZoneActivationCheckAsync(string zoneId, CancellationToken cancellationToken = default);

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
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
            int? ttl, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new DNS record for a zone. See the record object definitions for required attributes for each record type
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="ttl">Time to live for DNS record. Value of 1 is 'automatic'</param>
        /// <param name="priority">Used with some records like MX and SRV to determine priority. If you do not supply a priority for an MX record, a default value of 0 will be set</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
            int? ttl, int? priority, CancellationToken cancellationToken = default);

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
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content,
            int? ttl, int? priority, bool? proxied, CancellationToken cancellationToken = default);

        #endregion

        #region DeleteDnsRecordAsync

        /// <summary>
        /// Delete DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId, string identifier, CancellationToken cancellationToken = default);

        #endregion

        #region ExportDnsRecordsAsync

        /// <summary>
        /// Export your BIND config through this endpoint.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId, CancellationToken cancellationToken = default);

        #endregion

        #region GetDnsRecordsAsync

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
            string content, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
            string content, int? page, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter a zone's DNS records.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="type">DNS record type</param>
        /// <param name="name">DNS record name</param>
        /// <param name="content">DNS record content</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
            string content, int? page, int? perPage, CancellationToken cancellationToken = default);

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
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
            string content, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken = default);

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
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name,
            string content, int? page, int? perPage, OrderType? order, bool? match, CancellationToken cancellationToken = default);

        #endregion

        #region GetDnsRecordDetailsAsync

        /// <summary>
        /// Get all details of the specified dns record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId, string identifier, CancellationToken cancellationToken = default);

        #endregion

        #region ImportDnsRecordsAsync

        /// <summary>
        /// Import your BIND config through this endpoint.
        /// Notice: SOA DNS record type is not supported by CloudFlare
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="fileInfo">FileInfo of the file</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, CancellationToken cancellationToken = default);

        /// <summary>
        /// Import your BIND config through this endpoint.
        /// Notice: SOA DNS record type is not supported by CloudFlare
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="fileInfo">FileInfo of the file</param>
        /// <param name="proxied">Whether the record is receiving the performance and security benefits of CloudFlare</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, bool? proxied, CancellationToken cancellationToken = default);

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
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
            string content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update DNS record
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="identifier">Identifier of the record</param>
        /// <param name="type">The new DNS record type</param>
        /// <param name="name">The new DNS record name</param>
        /// <param name="content">The new DNS record content</param>
        /// <param name="ttl">The new Time to live for DNS record. Value of 1 is 'automatic'</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
            string content, int? ttl, CancellationToken cancellationToken = default);

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
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name,
            string content, int? ttl, bool? proxied, CancellationToken cancellationToken = default);

        #endregion

        #endregion

        #region Custom Hostname for a Zone

        #region CreateCustomHostnameAsync

        /// <summary>
        /// Add a new custom hostname and request that an SSL certificate be issued for it. One of three validation methods—http,
        /// cname, email—should be used, with 'http' recommended if the CNAME is already in place (or will be soon). Specifying 'email'
        /// will send an email to the WHOIS contacts on file for the base domain plus hostmaster, postmaster, webmaster, admin, administrator.
        /// Specifying 'cname' will return a CNAME that needs to be placed. If http is used and the domain is not already pointing to the Managed CNAME host,
        /// the PATCH method must be used once it is (to complete validation).
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">The custom hostname that will point to your hostname via CNAME</param>
        /// <param name="ssl">SSL properties used when creating the custom hostname</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> CreateCustomHostnameAsync(string zoneId, string hostname,
            CustomHostnameSsl ssl, CancellationToken cancellationToken = default);

        #endregion

        #region GetCustomHostnamesAsync

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, CancellationToken cancellationToken = default);


        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="hostname">Fully qualified domain name to match against. This parameter cannot be used with the 'id' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, CancellationToken cancellationToken = default);


        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken = default);

        /// <summary>
        /// List, search, sort, and filter all of your custom hostnames
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Hostname ID to match against. This ID was generated and returned during the initial custom_hostname creation.
        /// This parameter cannot be used with the 'hostname' parameter</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of hostnames per page</param>
        /// <param name="type">Field to order hostnames by</param>
        /// <param name="order">Direction to order hostnames</param>
        /// <param name="ssl">Whether to filter hostnames based on if they have SSL enabled</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page,
            int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken = default);

        #endregion

        #region GetCustomHostnameDetailsAsync

        /// <summary>
        /// Get all details of the specified custom hostname
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId"></param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> GetCustomHostnameDetailsAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken = default);

        #endregion

        #region EditCustomHostnameAsync

        /// <summary>
        /// Modify SSL configuration for a custom hostname. When sent with SSL config that matches existing config,
        /// used to indicate that hostname should pass domain control validation (DCV). Can also be used to change validation type,
        /// e.g., from 'http' to 'email'.
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <param name="patchCustomHostname">SSL properties used when creating the custom hostname</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> EditCustomHostnameAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname, CancellationToken cancellationToken = default);

        #endregion

        #region DeleteCustomHostnameAsync

        /// <summary>
        /// Delete Custom Hostname (and any issued SSL certificates)
        /// </summary>
        /// <param name="zoneId">Zone identifier</param>
        /// <param name="customHostnameId">Custom hostname identifier</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<CustomHostname>> DeleteCustomHostnameAsync(string zoneId, string customHostnameId, CancellationToken cancellationToken = default);

        #endregion

        #endregion
    }
}
