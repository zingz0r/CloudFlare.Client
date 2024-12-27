using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.TurnstileWidgets;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;

namespace CloudFlare.Client.Client.Accounts;

/// <inheritdoc cref="CloudFlare.Client.Client.Accounts.ITurnStileWidgets" />
public class TurnStileWidgets : ApiContextBase<IConnection>, ITurnStileWidgets
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TurnStileWidgets"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public TurnStileWidgets(IConnection connection)
        : base(connection)
    {
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<TurnstileWidget>> AddAsync(string accountId, NewTurnstileWidget turnstileWidget, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}";
        return await Connection.PostAsync<TurnstileWidget, NewTurnstileWidget>(requestUri, turnstileWidget, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<TurnstileWidget>> DeleteAsync(string accountId, string turnstileWidgetId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}/{turnstileWidgetId}";
        return await Connection.DeleteAsync<TurnstileWidget>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<IReadOnlyList<TurnstileWidget>>> GetAsync(string accountId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}";
        return await Connection.GetAsync<IReadOnlyList<TurnstileWidget>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<TurnstileWidget>> GetDetailsAsync(string accountId, string turnstileWidgetId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}/{turnstileWidgetId}";
        return await Connection.GetAsync<TurnstileWidget>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<TurnstileWidget>> UpdateAsync(string accountId, TurnstileWidget turnstileWidget, CancellationToken cancellationToken = default)
    {
        var updatedTurnstileWidget = new UpdatedTurnstileWidget
        {
            BotFightMode = turnstileWidget.BotFightMode,
            ClearanceLevel = turnstileWidget.ClearanceLevel,
            Domains = turnstileWidget.Domains,
            Mode = turnstileWidget.Mode,
            Name = turnstileWidget.Name,
            OffLabel = turnstileWidget.OffLabel,
        };

        var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}/{turnstileWidget.Id}";
        return await Connection.PutAsync<TurnstileWidget, UpdatedTurnstileWidget>(requestUri, updatedTurnstileWidget, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<TurnstileWidget>> RotateSecretAsync(string accountId, string turnstileWidgetId, bool invalidateImmediately, CancellationToken cancellationToken = default)
    {
        var body = new Dictionary<string, bool> { { Validation.InvalidateImmediately, invalidateImmediately } };

        var requestUri = $"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.TurnstileWidgets}/{turnstileWidgetId}/{AccountEndpoints.RotateSecret}";
        return await Connection.PostAsync<TurnstileWidget, Dictionary<string, bool>>(requestUri, body, cancellationToken).ConfigureAwait(false);
    }
}
