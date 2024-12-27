using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Client.Accounts;

/// <summary>
/// Interface for interacting with roles
/// </summary>
public interface IRoles
{
    /// <summary>
    /// Get all available roles for an account
    /// </summary>
    /// <param name="accountId">Account identifier tag</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <param name="displayOptions">Display Options</param>
    /// <returns>The requested role</returns>
    Task<CloudFlareResult<IReadOnlyList<Role>>> GetAsync(string accountId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get information about a specific role for an account
    /// </summary>
    /// <param name="accountId">Account identifier tag</param>
    /// <param name="roleId">Role identifier tag</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The requested role details</returns>
    Task<CloudFlareResult<Role>> GetDetailsAsync(string accountId, string roleId, CancellationToken cancellationToken = default);
}
