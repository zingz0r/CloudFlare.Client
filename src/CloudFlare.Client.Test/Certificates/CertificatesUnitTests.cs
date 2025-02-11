using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Certificates;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Certificates;

public class CertificatesUnitTests
{
    private readonly WireMockServer _wireMockServer;
    private ConnectionInfo _connectionInfo;

    public CertificatesUnitTests()
    {
        _wireMockServer = WireMockServer.Start();
        _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
    }
    
    [Fact]
    public async Task TestCreateCertificateAsync()
    {
        var certificate = CertificatesTestData.Certificates.First();
        var newcertificate = new NewOriginCaCertificate
        {
            Csr = certificate.Csr,
            Hostnames = certificate.Hostnames,
            RequestedValidity = certificate.RequestedValidity,
            RequestRequestType = certificate.RequestType
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{CertificateEndpoints.Base}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(certificate)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Certificates.AddAsync(newcertificate);

        result.Result.Should().BeEquivalentTo(certificate, x => x.Excluding(y => y.ExpiresOnRaw));
    }

    [Fact]
    public async Task TestGetCertificatesAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var displayOptions = new DisplayOptions { Page = 1, PerPage = 20, Order = OrderType.Asc };

        _wireMockServer
            .Given(Request.Create()
                .WithPath($"/{CertificateEndpoints.Base}/")
                .WithParam(Filtering.ZoneId, zone.Id)
                .UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(CertificatesTestData.Certificates)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var certificates = await client.Certificates.GetAsync(zone.Id, displayOptions);

        certificates.Result.Should().BeEquivalentTo(CertificatesTestData.Certificates, x => x.Excluding(y => y.ExpiresOnRaw));
    }
    
    [Fact]
    public async Task TestGetCertificateDetailsAsync()
    {
        var certificate = CertificatesTestData.Certificates.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/{CertificateEndpoints.Base}/{certificate.Id}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(certificate)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var certificatedetails = await client.Certificates.GetDetailsAsync(certificate.Id);

        certificatedetails.Result.Should().BeEquivalentTo(certificate, x => x.Excluding(y => y.ExpiresOnRaw));
    }

    [Fact]
    public async Task TestRevocationCertificateAsync()
    {
        var certificate = CertificatesTestData.Certificates.First();
        var expected = new OriginCaCertificate() { Id = certificate.Id };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{CertificateEndpoints.Base}/{certificate.Id}").UsingDelete())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var revoke = await client.Certificates.RevokeAsync(certificate.Id);

        revoke.Result.Should().BeEquivalentTo(expected);
    }
}
