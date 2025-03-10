﻿using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Client.Users;

/// <inheritdoc cref="CloudFlare.Client.Client.Users.IUsers" />
public class Users : ApiContextBase<IConnection>, IUsers
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Users"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public Users(IConnection connection)
        : base(connection)
    {
        Memberships = new Memberships(connection);
    }

    /// <inheritdoc />
    public IMemberships Memberships { get; set; }

    /// <inheritdoc />
    public async Task<CloudFlareResult<User>> GetDetailsAsync(CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri(UserEndpoints.Base);
        return await Connection.GetAsync<User>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<User>> UpdateAsync(User editedUser, CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri(UserEndpoints.Base);
        return await Connection.PatchAsync(requestUri, editedUser, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<CloudFlareResult<VerifyToken>> VerifyAsync(CancellationToken cancellationToken = default)
    {
        var requestUri = new RelativeUri($"{UserEndpoints.Base}/{TokenEndpoints.Base}/{TokenEndpoints.Verify}");
        return await Connection.GetAsync<VerifyToken>(requestUri, cancellationToken).ConfigureAwait(false);
    }
}
