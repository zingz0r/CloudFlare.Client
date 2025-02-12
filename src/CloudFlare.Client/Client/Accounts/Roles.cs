using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client.Accounts;

/// <inheritdoc cref="CloudFlare.Client.Client.Accounts.IRoles" />
public class Roles : ApiContextBase<IConnection>, IRoles
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Roles"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public Roles(IConnection connection)
        : base(connection)
    {
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<IReadOnlyList<Role>>> GetAsync(string accountId, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
    {
        var parameters = new ParameterBuilder()
            .InsertValue(Filtering.Page, displayOptions?.Page)
            .InsertValue(Filtering.PerPage, displayOptions?.PerPage);

        var requestUri = new RelativeUri($"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Roles}").AddParameters(parameters);
        return await Connection.GetAsync<IReadOnlyList<Role>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<Role>> GetDetailsAsync(string accountId, string roleId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{AccountEndpoints.Base}/{accountId}/{AccountEndpoints.Roles}/{roleId}");
        return await Connection.GetAsync<Role>(requestUri, cancellationToken).ConfigureAwait(false);
    }
}
