using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using CloudFlare.Client.Test.Attributes;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests.Zones
{
    public class CustomHostnamesUnitTests
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
            var filter = new CustomHostnameFilter { Hostname = hostname, OrderType = type, Ssl = ssl };
            var displayOptions = new DisplayOptions { Page = page, PerPage = perPage, Order = order };

            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostnames = await client.Zones.CustomHostnames.GetAsync(zoneId, filter, displayOptions);

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
            var filter = new CustomHostnameFilter { CustomHostnameId = id, OrderType = type, Ssl = ssl };
            var displayOptions = new DisplayOptions { Page = page, PerPage = perPage, Order = order };

            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostnameId = (await client.Zones.CustomHostnames.GetAsync(zoneId, filter, displayOptions)).Result.First().Id;
            var customHostnameDetails = await client.Zones.CustomHostnames.GetDetailsAsync(zoneId, customHostnameId);

            customHostnameDetails.Should().NotBeNull();
            customHostnameDetails.Errors?.Should().BeEmpty();
            customHostnameDetails.Success.Should().BeTrue();
        }

        [MinimumPlanEnterpriseFact]
        public async Task TestGetCustomHostnameDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostnameId = (await client.Zones.CustomHostnames.GetAsync(zoneId)).Result.First().Id;
            var customHostnameDetails = await client.Zones.CustomHostnames.GetDetailsAsync(zoneId, customHostnameId);

            customHostnameDetails.Should().NotBeNull();
            customHostnameDetails.Errors?.Should().BeEmpty();
            customHostnameDetails.Success.Should().BeTrue();
        }

        [MinimumPlanEnterpriseFact(Skip = "Would cause edited hostname")]
        public async Task TestEditCustomHostnameAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostname = (await client.Zones.CustomHostnames.GetAsync(zoneId)).Result.First();

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

            var editCustomHostname = await client.Zones.CustomHostnames.UpdateAsync(zoneId, customHostname.Id, patchData);

            editCustomHostname.Should().NotBeNull();
            editCustomHostname.Errors?.Should().BeEmpty();
            editCustomHostname.Success.Should().BeTrue();

            var filter = new CustomHostnameFilter { Hostname = customHostname.Hostname };
            var updatedCustomHostname = (await client.Zones.CustomHostnames.GetAsync(zoneId, filter)).Result.First();

            Assert.Equal(MethodType.Http, updatedCustomHostname.Ssl.Method);
        }

        [Fact(Skip = "Would cause deleted membership")]
        public async Task TestDeleteCustomHostnameAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostname = (await client.Zones.CustomHostnames.GetAsync(zoneId)).Result.First();
            var deleteCustomHostname = await client.Zones.CustomHostnames.DeleteAsync(zoneId, customHostname.Hostname);

            deleteCustomHostname.Should().NotBeNull();
            deleteCustomHostname.Errors?.Should().BeEmpty();
            deleteCustomHostname.Success.Should().BeTrue();
        }
    }
}
