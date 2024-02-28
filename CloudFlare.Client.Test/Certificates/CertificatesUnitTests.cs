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

namespace CloudFlare.Client.Test.Certificates
{
    public class CertificatesUnitTests
    {
        private readonly WireMockServer _wireMockServer;
        private readonly ConnectionInfo _connectionInfo;

        public CertificatesUnitTests()
        {
            _wireMockServer = WireMockServer.Start();
            _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
        }

        [Fact]
        public async Task TestCreateCertificateAsync()
        {
            var certificates = CertificatesTestData.Certificates.First();
            var certificate = new NewCertificate
            {
                CertificateSigningRequest = "",
                Hostnames = certificates.Hostnames
            };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{CertificateEndpoints.Base}").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(certificates)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var addCertificate = await client.Certificates.AddAsync(certificate);

            addCertificate.Result.Should().BeEquivalentTo(certificates);
        }

        [Fact]
        public async Task TestGetCertificatesAsync()
        {
            var displayOptions = new DisplayOptions { Page = 1, PerPage = 20, Order = OrderType.Asc };

            _wireMockServer
                .Given(Request.Create()
                    .WithPath($"/{CertificateEndpoints.Base}/")
                    .WithParam(Filtering.ZoneId)
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(CertificatesTestData.Certificates)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var certificates = await client.Certificates.GetAsync("023e105f4ecef8ad9ca31a8372d0c353", displayOptions);

            certificates.Result.Should().BeEquivalentTo(CertificatesTestData.Certificates);
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

            var certificateDetails = await client.Certificates.GetDetailsAsync(certificate.Id);

            certificateDetails.Result.Should().BeEquivalentTo(certificate);
        }

        [Fact]
        public async Task TestRevocationCertificateAsync()
        {
            var certificate = CertificatesTestData.Certificates.First();
            var revokeCertificate = new RevokedCertificate
            {
                Id = certificate.Id
            };

            _wireMockServer
                .Given(Request.Create().WithPath($"/{CertificateEndpoints.Base}/{certificate.Id}").UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(certificate)));

            using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

            var revocationCertificate = await client.Certificates.RevokeAsync(certificate.Id);

            revocationCertificate.Result.Should().BeEquivalentTo(revokeCertificate);
        }
    }
}
