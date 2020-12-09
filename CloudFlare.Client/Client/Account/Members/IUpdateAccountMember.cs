using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface IUpdateAccountMember
    {
        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, CancellationToken cancellationToken);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, CancellationToken cancellationToken);

        /// <summary>
        /// Modify an account member
        /// </summary>
        /// <param name="accountId">Account identifier tag</param>
        /// <param name="memberId">Membership identifier tag</param>
        /// <param name="roles">Roles assigned to this member</param>
        /// <param name="code">The unique activation code for the account membership</param>
        /// <param name="user">User object</param>
        /// <returns></returns>
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user);

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
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user, CancellationToken cancellationToken);

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
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user, MembershipStatus? status);

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
        Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IReadOnlyList<AccountRole> roles, string code, User user, MembershipStatus? status, CancellationToken cancellationToken);
    }
}