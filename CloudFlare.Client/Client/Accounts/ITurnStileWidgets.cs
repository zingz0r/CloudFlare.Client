using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.TurnstileWidgets;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Client.Accounts;

/// <summary>
/// Interface for interacting with turnstile widgets
/// </summary>
public interface ITurnStileWidgets
{
    /// <summary>
    /// Creates a turnstile widgets
    /// </summary>
    /// <param name="accountId">Account identifier tag</param>
    /// <param name="turnstileWidget">New turnstile widget details</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created turnstile widget</returns>
    Task<CloudFlareResult<TurnstileWidget>> AddAsync(string accountId, NewTurnstileWidget turnstileWidget, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a turnstile widgets
    /// </summary>
    /// <param name="accountId">Account identifier tag</param>
    /// <param name="turnstileWidgetId">Turnstile widget identifier tag</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The deleted turnstile widget</returns>
    Task<CloudFlareResult<TurnstileWidget>> DeleteAsync(string accountId, string turnstileWidgetId, CancellationToken cancellationToken = default);

    /// <summary>
    /// List all turnstile widgets
    /// </summary>
    /// <param name="accountId">Account identifier tag</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The requested turnstile widget</returns>
    Task<CloudFlareResult<IReadOnlyList<TurnstileWidget>>> GetAsync(string accountId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get information about a specific turnstile widget
    /// </summary>
    /// <param name="accountId">Account identifier tag</param>
    /// <param name="turnstileWidgetId">Turnstile widget identifier tag</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The requested turnstile widget details</returns>
    Task<CloudFlareResult<TurnstileWidget>> GetDetailsAsync(string accountId, string turnstileWidgetId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a turnstile widget
    /// </summary>
    /// <param name="accountId">Account identifier tag</param>
    /// <param name="turnstileWidget">Modified turnstile widget details</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated turnstile widget</returns>
    Task<CloudFlareResult<TurnstileWidget>> UpdateAsync(string accountId, TurnstileWidget turnstileWidget, CancellationToken cancellationToken = default);

    /// <summary>
    /// Generate a new secret key for this widget
    /// </summary>
    /// <param name="accountId">Account identifier tag</param>
    /// <param name="turnstileWidgetId">Turnstile widget identifier tag</param>
    /// <param name="invalidateImmediately">Whether it is set to false, the preceding secret remains valid for 2 hours. Note that secrets cannot be rotated again during the grace period.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The turnstile widget with the rotated secret</returns>
    Task<CloudFlareResult<TurnstileWidget>> RotateSecretAsync(string accountId, string turnstileWidgetId, bool invalidateImmediately, CancellationToken cancellationToken = default);
}
