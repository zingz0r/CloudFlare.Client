using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests
{
    public class ZoneUnitTests
    {
        [Theory(Skip = "Would cause new zone")]
        [InlineData(@"test_domain_full.com", ZoneType.Full)]
        [InlineData(@"test_domain_partial.com", ZoneType.Partial)]
        public async Task TestCreateZoneAsync(string name, ZoneType type)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var account = (await client.GetAccountsAsync()).Result.First();
            var zonesQueryResult = await client.CreateZoneAsync(name, type, account);

            Assert.NotNull(zonesQueryResult);
            Assert.Empty(zonesQueryResult.Errors);
            Assert.True(zonesQueryResult.Success);
        }

        [Theory]
        [InlineData(null, null, null, null, null, null)]
        [InlineData("tothnet.hu", null, null, null, null, null)]
        [InlineData(null, ZoneStatus.Active, null, null, null, null)]
        [InlineData(null, ZoneStatus.Deactivated, null, null, null, null)]
        [InlineData(null, ZoneStatus.Deleted, null, null, null, null)]
        [InlineData(null, ZoneStatus.Initializing, null, null, null, null)]
        [InlineData(null, ZoneStatus.Moved, null, null, null, null)]
        [InlineData(null, ZoneStatus.Pending, null, null, null, null)]
        [InlineData(null, null, 0, null, null, null)]
        [InlineData(null, null, null, 100, null, null)]
        [InlineData(null, null, null, null, OrderType.Desc, null)]
        [InlineData(null, null, null, null, OrderType.Asc, null)]
        [InlineData(null, null, null, null, null, true)]
        [InlineData(null, null, null, null, null, false)]
        public async Task TestGetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage,
            OrderType? order, bool? match)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = await client.GetZonesAsync(name, status, page, perPage, order, match);

            Assert.NotNull(zonesQueryResult);
            Assert.Empty(zonesQueryResult.Errors);
            Assert.True(zonesQueryResult.Success);
        }

        [Fact]
        public async Task TestGetZoneDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.GetZonesAsync()).Result.First();
            var zoneDetailsQueryResult = await client.GetZoneDetailsAsync(zonesQueryResult.Id);

            Assert.NotNull(zoneDetailsQueryResult);
            Assert.Empty(zoneDetailsQueryResult.Errors);
            Assert.True(zoneDetailsQueryResult.Success);
        }

        [Fact(Skip = "Would cause edited zone")]
        public async Task TestEditZoneAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.GetZonesAsync()).Result.First();
            var editZoneQueryResult = await client.EditZoneAsync(zonesQueryResult.Id, new PatchZone
            {
                Paused = false,
                Plan = new Plan
                {
                    Id = "e592fd9519420ba7405e1307bff33214"
                },
                VanityNameServers = new List<string>
                {
                    "ns1.example.com",
                    "ns2.example.com"
                }
            });

            Assert.NotNull(editZoneQueryResult);
            Assert.Empty(editZoneQueryResult.Errors);
            Assert.True(editZoneQueryResult.Success);
        }

        [Fact(Skip = "Would cause deleted zone")]

        public async Task TestDeleteZoneAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.GetZonesAsync()).Result.First();
            var deletedZoneQueryResult = await client.DeleteZoneAsync(zonesQueryResult.Id);

            Assert.NotNull(deletedZoneQueryResult);
            Assert.Empty(deletedZoneQueryResult.Errors);
            Assert.True(deletedZoneQueryResult.Success);
        }

        [Fact]
        public async Task TestZoneActivationCheckAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.GetZonesAsync()).Result.First();
            var zoneActivationCheckQueryResult = await client.ZoneActivationCheckAsync(zonesQueryResult.Id);

            Assert.NotNull(zoneActivationCheckQueryResult);

            var notAvailable = new List<int>
            {
                1224, // You may only perform this action once per hour.
            };

            if (!zoneActivationCheckQueryResult.Errors.Any(x => notAvailable.Contains(x.Code)))
            {
                Assert.True(zoneActivationCheckQueryResult.Success);
                if (zoneActivationCheckQueryResult.Errors != null)
                {
                    Assert.Empty(zoneActivationCheckQueryResult.Errors);
                }
            }
        }

        [Fact]

        public async Task TestPurgeAllFilesAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.GetZonesAsync()).Result.First();
            var purgeAllFilesAsyncQueryResult = await client.PurgeAllFilesAsync(zonesQueryResult.Id, true);

            Assert.NotNull(purgeAllFilesAsyncQueryResult);
            Assert.Empty(purgeAllFilesAsyncQueryResult.Errors);
            Assert.True(purgeAllFilesAsyncQueryResult.Success);
        }
    }
}
