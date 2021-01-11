using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Interfaces
{
    public interface IMembers
    {
        /// <summary>
        /// Add a user to the list of members for this account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="emailAddress">Your contact email address</param>
        /// <param name="roles">Array of roles associated with this member</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> AddAsync(string accountId, string emailAddress, IReadOnlyList<AccountRole> roles);

        /// <summary>
        /// Add a user to the list of members for this account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="emailAddress">Your contact email address</param>
        /// <param name="roles">Array of roles associated with this member</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> AddAsync(string accountId, string emailAddress, IReadOnlyList<AccountRole> roles, CancellationToken cancellationToken);

        /// <summary>
        /// Remove a member from an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> DeleteAsync(string accountId, string memberId);

        /// <summary>
        /// Remove a member from an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> DeleteAsync(string accountId, string memberId, CancellationToken cancellationToken);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, CancellationToken cancellationToken);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page, CancellationToken cancellationToken);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page, int? perPage);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page, int? perPage, CancellationToken cancellationToken);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page, int? perPage, OrderType? order);

        /// <summary>
        /// List all members of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="page">Page number of paginated results</param>
        /// <param name="perPage">Number of DNS records per page</param>
        /// <param name="order">Field to order records by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<IReadOnlyList<AccountMember>>> GetAsync(string accountId, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken);

        /// <summary>
        /// Get information about a specific member of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> GetDetailsAsync(string accountId, string memberId);

        /// <summary>
        /// Get information about a specific member of an account
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> GetDetailsAsync(string accountId, string memberId, CancellationToken cancellationToken);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, CancellationToken cancellationToken);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, CancellationToken cancellationToken);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <param name="user">User object</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user);

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
        Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user, CancellationToken cancellationToken);

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
        Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user, MembershipStatus? status);

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
        Task<CloudFlareResult<AccountMember>> UpdateAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user, MembershipStatus? status, CancellationToken cancellationToken);
    }
}