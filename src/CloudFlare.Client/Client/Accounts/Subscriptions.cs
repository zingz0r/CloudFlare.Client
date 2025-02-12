using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client.Accounts;

/// <inheritdoc cref="CloudFlare.Client.Client.Accounts.ISubscriptions" />
public class Subscriptions : ApiContextBase<IConnection>, ISubscriptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Subscriptions"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public Subscriptions(IConnection connection)
        : base(connection)
    {
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<Subscription>> AddAsync(string accountId, Subscription subscription, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Subscriptions}");
        return await Connection.PostAsync(requestUri, subscription, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<DeletedSubscription>> DeleteAsync(string accountId, string subscriptionId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Subscriptions}/{subscriptionId}");
        return await Connection.DeleteAsync<DeletedSubscription>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<IReadOnlyList<Subscription>>> GetAsync(string accountId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Subscriptions}");
        return await Connection.GetAsync<IReadOnlyList<Subscription>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<Subscription>> UpdateAsync(string accountId, Subscription subscription, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Subscriptions}/{subscription.Id}");
        return await Connection.PostAsync(requestUri, subscription, cancellationToken).ConfigureAwait(false);
    }
}
