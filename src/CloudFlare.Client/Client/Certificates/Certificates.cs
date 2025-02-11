using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Certificates;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Helpers;

namespace CloudFlare.Client.Client.Certificates;

/// <inheritdoc cref="ICertificates"/>
public class Certificates : ApiContextBase<IConnection>, ICertificates
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Certificates"/> class
    /// </summary>
    /// <param name="connection">Connection settings</param>
    public Certificates(IConnection connection)
        : base(connection)
    {
    }

    
    /// <inheritdoc />
    public Task<CloudFlareResult<OriginCaCertificate>> AddAsync(NewOriginCaCertificate newCertificate, CancellationToken cancellationToken = default)
    {
        return Connection.PostAsync<OriginCaCertificate, NewOriginCaCertificate>(CertificateEndpoints.Base, newCertificate, cancellationToken);
    }
    
    /// <inheritdoc />
    public async Task<CloudFlareResult<IReadOnlyList<OriginCaCertificate>>> GetAsync(string zoneId, UnOrderableDisplayOptions displayOptions = null, CancellationToken cancellationToken = default)
    {
        var builder = new ParameterBuilderHelper()
            .InsertValue(Filtering.Page, displayOptions?.Page)
            .InsertValue(Filtering.PerPage, displayOptions?.PerPage)
            .InsertValue(Filtering.ZoneId, zoneId);

        var requestUri = $"{CertificateEndpoints.Base}";

        if (builder.ParameterCollection.HasKeys())
        {
            requestUri = $"{requestUri}/?{builder.ParameterCollection}";
        }

        return await Connection.GetAsync<IReadOnlyList<OriginCaCertificate>>(requestUri, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public Task<CloudFlareResult<OriginCaCertificate>> GetDetailsAsync(string certificateId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{CertificateEndpoints.Base}/{certificateId}";
        return Connection.GetAsync<OriginCaCertificate>(requestUri, cancellationToken);
    }


    /// <inheritdoc />
    public Task<CloudFlareResult<OriginCaCertificate>> RevokeAsync(string certificateId, CancellationToken cancellationToken = default)
    {
        var requestUri = $"{CertificateEndpoints.Base}/{certificateId}";
        return Connection.DeleteAsync<OriginCaCertificate>(requestUri, cancellationToken);
    }
}
