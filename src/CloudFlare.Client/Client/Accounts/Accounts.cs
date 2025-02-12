using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client.Accounts;

/// <inheritdoc cref="CloudFlare.Client.Client.Accounts.IAccounts" />
public class Accounts : ApiContextBase<IConnection>, IAccounts
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Accounts"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public Accounts(IConnection connection)
        : base(connection)
    {
        Members = new Members(connection);
        Roles = new Roles(connection);
        Subscriptions = new Subscriptions(connection);
        TurnStileWidgets = new TurnStileWidgets(connection);
    }

    /// <inheritdoc />
    public IMembers Members { get; }

    /// <inheritdoc />
    public IRoles Roles { get; }

    /// <inheritdoc />
    public ISubscriptions Subscriptions { get; }

    /// <inheritdoc />
    public ITurnStileWidgets TurnStileWidgets { get; }

    /// <inheritdoc />
    public async Task<CloudFlareResult<IReadOnlyList<Account>>> GetAsync(DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
    {
        var parameters = new ParameterBuilder()
            .InsertValue(Filtering.Page, displayOptions?.Page)
            .InsertValue(Filtering.PerPage, displayOptions?.PerPage)
            .InsertValue(Filtering.Direction, displayOptions?.Order);

        var requestUri = new RelativeUri(AccountEndpoints.Base).AddParameters(parameters);

        return await Connection.GetAsync<IReadOnlyList<Account>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<Account>> GetDetailsAsync(string accountId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{AccountEndpoints.Base}/{accountId}");
        return await Connection.GetAsync<Account>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<Account>> UpdateAsync(string accountId, string name, AdditionalAccountSettings additionalAccountSettings = null, CancellationToken cancellationToken = default)
    {
        var account = new Account
        {
            Id = accountId,
            Name = name,
            Settings = additionalAccountSettings
        };

        var requestUri = new RelativeUri($"{AccountEndpoints.Base}/{accountId}");
        return await Connection.PutAsync(requestUri, account, cancellationToken).ConfigureAwait(false);
    }
}
