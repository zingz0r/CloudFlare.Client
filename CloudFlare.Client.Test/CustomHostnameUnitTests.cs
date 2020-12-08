using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using CloudFlare.Client.Test.FactAttributes;
using CloudFlare.Client.Test.TheoryAttributes;
using Xunit;

namespace CloudFlare.Client.Test
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

            Assert.NotNull(customHostnames);
            Assert.Empty(customHostnames.Errors);
            Assert.True(customHostnames.Success);
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

            Assert.NotNull(customHostnameDetails);
            Assert.Empty(customHostnameDetails.Errors);
            Assert.True(customHostnameDetails.Success);
        }

        [MinimumPlanEnterpriseFact]
        public async Task TestGetCustomHostnameDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zoneId = (await client.GetZonesAsync()).Result.First().Id;
            var customHostnameId = (await client.GetCustomHostnamesAsync(zoneId)).Result.First().Id;
            var customHostnameDetails = await client.GetCustomHostnameDetailsAsync(zoneId, customHostnameId);

            Assert.NotNull(customHostnameDetails);
            Assert.Empty(customHostnameDetails.Errors);
            Assert.True(customHostnameDetails.Success);
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

            Assert.NotNull(editCustomHostname);
            Assert.Empty(editCustomHostname.Errors);
            Assert.True(editCustomHostname.Success);

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

            Assert.NotNull(deleteCustomHostname);
            Assert.Empty(deleteCustomHostname.Errors);
            Assert.True(deleteCustomHostname.Success);
        }
    }
}
