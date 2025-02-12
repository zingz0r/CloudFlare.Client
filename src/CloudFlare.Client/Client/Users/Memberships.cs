using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Users.Memberships;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client.Users;

/// <inheritdoc cref="CloudFlare.Client.Client.Users.IMemberships" />
public class Memberships : ApiContextBase<IConnection>, IMemberships
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Memberships"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public Memberships(IConnection connection)
        : base(connection)
    {
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<Membership>> DeleteAsync(string membershipId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{MembershipEndpoints.Base}/{membershipId}");
        return await Connection.DeleteAsync<Membership>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<IReadOnlyList<Membership>>> GetAsync(MembershipFilter filter = null, DisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
    {
        var parameters = new ParameterBuilder()
            .InsertValue(Filtering.Status, filter?.Status)
            .InsertValue(Filtering.AccountName, filter?.AccountName)
            .InsertValue(Filtering.Order, filter?.MembershipOrder)
            .InsertValue(Filtering.Page, displayOptions?.Page)
            .InsertValue(Filtering.PerPage, displayOptions?.PerPage)
            .InsertValue(Filtering.Direction, displayOptions?.Order);

        var requestUri = new RelativeUri(MembershipEndpoints.Base).AddParameters(parameters);
        return await Connection.GetAsync<IReadOnlyList<Membership>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<Membership>> GetDetailsAsync(string membershipId, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{MembershipEndpoints.Base}/{membershipId}");
        return await Connection.GetAsync<Membership>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<Membership>> UpdateAsync(string membershipId, MembershipStatus status, CancellationToken cancellationToken = default)
    {
        var data = new Dictionary<string, MembershipStatus>
        {
            { Filtering.Status, status }
        };

        var requestUri = new RelativeUri($"{MembershipEndpoints.Base}/{membershipId}");
        return await Connection.PutAsync<Membership, Dictionary<string, MembershipStatus>>(requestUri, data, cancellationToken).ConfigureAwait(false);
    }
}
