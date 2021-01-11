using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface IUserMemberships
    {
        /// <summary>
        /// Remove the associated member from an account
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> DeleteAsync(string membershipId);

        /// <summary>
        /// Remove the associated member from an account
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> DeleteAsync(string membershipId, CancellationToken cancellationToken);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync();

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(CancellationToken cancellationToken);


        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, CancellationToken cancellationToken);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, CancellationToken cancellationToken);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, CancellationToken cancellationToken);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage, CancellationToken cancellationToken);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <param name="membershipOrder">Field to order memberships by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage, MembershipOrder? membershipOrder);

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
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, CancellationToken cancellationToken);

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
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, OrderType? order);

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
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetAsync(MembershipStatus? status, string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, OrderType? order, CancellationToken cancellationToken);

        /// <summary>
        /// Get a specific membership
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetDetailsAsync(string membershipId);

        /// <summary>
        /// Get a specific membership
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetDetailsAsync(string membershipId, CancellationToken cancellationToken);

        /// <summary>
        /// Accept or reject this account invitation
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="status">Whether to accept or reject this account invitation</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> UpdateAsync(string membershipId, MembershipStatus status);

        /// <summary>
        /// Accept or reject this account invitation
        /// </summary>
        /// <param name="membershipId">Membership identifier tag</param>
        /// <param name="status">Whether to accept or reject this account invitation</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> UpdateAsync(string membershipId, MembershipStatus status, CancellationToken cancellationToken);
    }
}