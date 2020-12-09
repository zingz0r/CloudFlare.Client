using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using CloudFlare.Client.Test.FactAttributes;
using CloudFlare.Client.Test.TheoryAttributes;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests
{
    public class CustomHostnameUnitTests
    {
        [MinimumPlanEnterpriseTheory]
        [InlineData(null, null, null, null, null, null)]
        [InlineData(null, null, 0, null, null, null)]
        [InlineData(null, null, null, 100, null, null)]
        [InlineData(null, null, null, null, OrderType.Asc, null)]
        [InlineData(null, null, null, null, OrderType.Desc, null)]
        [InlineData(null, null, null, null, null, true)]
        [InlineData(null, null, null, null, null, false)]
        public async Task TestGetCustomHostnamesAsync(string hostname, int? page, int? perPage,
            CustomHostnameOrderType? type, OrderType? order, bool? ssl)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.GetZonesAsync()).Result.First().Id;
            var customHostnames = await client.GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, order, ssl);

            customHostnames.Should().NotBeNull();
            customHostnames.Errors?.Should().BeEmpty();
            customHostnames.Success.Should().BeTrue();
        }

        [MinimumPlanEnterpriseTheory]
        [InlineData(null, null, null, null, null, null)]
        [InlineData(null, null, 0, null, null, null)]
        [InlineData(null, null, null, 100, null, null)]
        [InlineData(null, null, null, null, OrderType.Asc, null)]
        [InlineData(null, null, null, null, OrderType.Desc, null)]
        [InlineData(null, null, null, null, null, true)]
        [InlineData(null, null, null, null, null, false)]
        public async Task TestGetCustomHostnamesByIdAsync(string id, int? page, int? perPage,
            CustomHostnameOrderType? type, OrderType? order, bool? ssl)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.GetZonesAsync()).Result.First().Id;
            var customHostnameId = (await client.GetCustomHostnamesByIdAsync(zoneId, id, page, perPage, type, order, ssl)).Result.First().Id;
            var customHostnameDetails = await client.GetCustomHostnameDetailsAsync(zoneId, customHostnameId);

            customHostnameDetails.Should().NotBeNull();
            customHostnameDetails.Errors?.Should().BeEmpty();
            customHostnameDetails.Success.Should().BeTrue();
        }

        [MinimumPlanEnterpriseFact]
        public async Task TestGetCustomHostnameDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.GetZonesAsync()).Result.First().Id;
            var customHostnameId = (await client.GetCustomHostnamesAsync(zoneId)).Result.First().Id;
            var customHostnameDetails = await client.GetCustomHostnameDetailsAsync(zoneId, customHostnameId);

            customHostnameDetails.Should().NotBeNull();
            customHostnameDetails.Errors?.Should().BeEmpty();
            customHostnameDetails.Success.Should().BeTrue();
        }

        [MinimumPlanEnterpriseFact(Skip = "Would cause edited hostname")]
        public async Task TestEditCustomHostnameAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.GetZonesAsync()).Result.First().Id;
            var customHostname = (await client.GetCustomHostnamesAsync(zoneId)).Result.First();

            var patchData = new PatchCustomHostname
            {
                Ssl = new CustomHostnameSsl
                {
                    Method = MethodType.Http,
                    Settings = new CustomHostnameSslSettings
                    {
                        Ciphers = new List<string>
                        {
                            "ECDHE-RSA-AES128-GCM-SHA256",
                            "AES128-SHA"
                        },
                        Http2 = FeatureStatus.On,
                        MinTlsVersion = TlsVersion.Tls12,
                        Tls13 = FeatureStatus.On
                    },
                }
            };

            var editCustomHostname = await client.EditCustomHostnameAsync(zoneId, customHostname.Id, patchData);

            editCustomHostname.Should().NotBeNull();
            editCustomHostname.Errors?.Should().BeEmpty();
            editCustomHostname.Success.Should().BeTrue();

            var updatedCustomHostname = (await client.GetCustomHostnamesAsync(zoneId, customHostname.Hostname)).Result.First();

            Assert.Equal(MethodType.Http, updatedCustomHostname.Ssl.Method);
        }

        [Fact(Skip = "Would cause deleted membership")]
        public async Task TestDeleteCustomHostnameAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.GetZonesAsync()).Result.First().Id;
            var customHostname = (await client.GetCustomHostnamesAsync(zoneId)).Result.First();
            var deleteCustomHostname = await client.DeleteCustomHostnameAsync(zoneId, customHostname.Hostname);

            deleteCustomHostname.Should().NotBeNull();
            deleteCustomHostname.Errors?.Should().BeEmpty();
            deleteCustomHostname.Success.Should().BeTrue();
        }
    }
}
