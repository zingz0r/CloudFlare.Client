using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Users.Memberships;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Client.Users;

/// <summary>
/// Interface for interacting with memberships
/// </summary>
public interface IMemberships
{
    /// <summary>
    /// Remove the associated member from an account
    /// </summary>
    /// <param name="membershipId">Membership identifier tag</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The deleted membership</returns>
    Task<CloudFlareResult<Membership>> DeleteAsync(string membershipId, CancellationToken cancellationToken = default);

    /// <summary>
    /// List memberships of accounts the user can access
    /// </summary>
    /// <param name="filter">Membership's filtering options</param>
    /// <param name="displayOptions">Display options</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The requested membership</returns>
    Task<CloudFlareResult<IReadOnlyList<Membership>>> GetAsync(MembershipFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a specific membership
    /// </summary>
    /// <param name="membershipId">Membership identifier tag</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The requested membership details</returns>
    Task<CloudFlareResult<Membership>> GetDetailsAsync(string membershipId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Accept or reject this account invitation
    /// </summary>
    /// <param name="membershipId">Membership identifier tag</param>
    /// <param name="status">Whether to accept or reject this account invitation</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated membership</returns>
    Task<CloudFlareResult<Membership>> UpdateAsync(string membershipId, MembershipStatus status, CancellationToken cancellationToken = default);
}
