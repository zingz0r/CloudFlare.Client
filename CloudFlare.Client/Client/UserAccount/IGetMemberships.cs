using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IGetMemberships
    {
        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync();

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(CancellationToken cancellationToken);


        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, CancellationToken cancellationToken);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, CancellationToken cancellationToken);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page, CancellationToken cancellationToken);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage, CancellationToken cancellationToken);

        /// <summary>
        /// List memberships of accounts the user can access
        /// </summary>
        /// <param name="status">Status of this membership</param>
        /// <param name="accountName">Account name</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of memberships per page</param>
        /// <param name="membershipOrder">Field to order memberships by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage, MembershipOrder? membershipOrder);

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
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage, MembershipOrder? membershipOrder, CancellationToken cancellationToken);

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
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage, MembershipOrder? membershipOrder, OrderType? order);

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
        Task<CloudFlareResult<IReadOnlyList<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page,
            int? perPage, MembershipOrder? membershipOrder, OrderType? order, CancellationToken cancellationToken);

    }
}