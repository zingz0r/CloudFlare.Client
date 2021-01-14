using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Enumerators;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Zones
{
    public class CustomHostnamesUnitTests
    {
        [Fact]
        public async Task TestAddCustomHostnameAsync()
        {
            using var client = new CloudFlareClient(Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var addCustomHostname = await client.Zones.CustomHostnames.AddAsync(zoneId, "test",
                new CustomHostnameSsl
                {
                    Method = MethodType.Cname,
                    Settings = new AdditionalCustomHostnameSslSettings
                    {
                        Ciphers = new List<string>
                        {
                            "CDHE-ECDSA-CHACHA20-POLY1305"
                        },
                        Http2 = FeatureStatus.On,
                        MinTlsVersion = TlsVersion.Tls13,
                        Tls13 = FeatureStatus.On
                    },
                    Type = DomainValidationType.Dv
                });

            addCustomHostname.Should().NotBeNull();
            addCustomHostname.Errors?.Should().BeEmpty();
            addCustomHostname.Success.Should().BeTrue();
        }

        [Theory]
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

            using var client = new CloudFlareClient(Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostnames = await client.Zones.CustomHostnames.GetAsync(zoneId, filter, displayOptions);

            customHostnames.Should().NotBeNull();
            customHostnames.Errors?.Should().BeEmpty();
            customHostnames.Success.Should().BeTrue();
        }

        [Theory]
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

            using var client = new CloudFlareClient(Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostnameId = (await client.Zones.CustomHostnames.GetAsync(zoneId, filter, displayOptions)).Result.First().Id;
            var customHostnameDetails = await client.Zones.CustomHostnames.GetDetailsAsync(zoneId, customHostnameId);

            customHostnameDetails.Should().NotBeNull();
            customHostnameDetails.Errors?.Should().BeEmpty();
            customHostnameDetails.Success.Should().BeTrue();
        }

        [Fact]
        public async Task TestGetCustomHostnameDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostnameId = (await client.Zones.CustomHostnames.GetAsync(zoneId)).Result.First().Id;
            var customHostnameDetails = await client.Zones.CustomHostnames.GetDetailsAsync(zoneId, customHostnameId);

            customHostnameDetails.Should().NotBeNull();
            customHostnameDetails.Errors?.Should().BeEmpty();
            customHostnameDetails.Success.Should().BeTrue();
        }

        [Fact]
        public async Task TestEditCustomHostnameAsync()
        {
            using var client = new CloudFlareClient(Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostname = (await client.Zones.CustomHostnames.GetAsync(zoneId)).Result.First();

            var patchData = new ModifiedCustomHostname
            {
                Ssl = new CustomHostnameSsl
                {
                    Method = MethodType.Http,
                    Settings = new AdditionalCustomHostnameSslSettings
                    {
                        Ciphers = new List<string>
                        {
                            "ECDHE-RSA-AES128-GCM-SHA256",
                            "AES128-SHA"
                        },
                        Http2 = FeatureStatus.On,
                        MinTlsVersion = TlsVersion.Tls12,
                        Tls13 = FeatureStatus.On
                    }
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

        [Fact]
        public async Task TestDeleteCustomHostnameAsync()
        {
            using var client = new CloudFlareClient(Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostname = (await client.Zones.CustomHostnames.GetAsync(zoneId)).Result.First();
            var deleteCustomHostname = await client.Zones.CustomHostnames.DeleteAsync(zoneId, customHostname.Hostname);

            deleteCustomHostname.Should().NotBeNull();
            deleteCustomHostname.Errors?.Should().BeEmpty();
            deleteCustomHostname.Success.Should().BeTrue();
        }

        [Fact]
        public async Task TestUpdateCustomHostnameAsync()
        {
            using var client = new CloudFlareClient(Credentials.Authentication);
            var zoneId = (await client.Zones.GetAsync()).Result.First().Id;
            var customHostname = (await client.Zones.CustomHostnames.GetAsync(zoneId)).Result.First();
            var updatedCustomHostname = await client.Zones.CustomHostnames.UpdateAsync(zoneId, customHostname.Id, new ModifiedCustomHostname
            {
                Ssl = new CustomHostnameSsl
                {
                    Method = MethodType.Http,
                    Settings = new AdditionalCustomHostnameSslSettings
                    {
                        Ciphers = new List<string>
                        {
                            "ECDHE-RSA-AES128-GCM-SHA256",
                            "AES128-SHA"
                        },
                        Http2 = FeatureStatus.On,
                        MinTlsVersion = TlsVersion.Tls12,
                        Tls13 = FeatureStatus.On
                    }
                }
            });

            updatedCustomHostname.Should().NotBeNull();
            updatedCustomHostname.Errors?.Should().BeEmpty();
            updatedCustomHostname.Success.Should().BeTrue();
        }
    }
}
