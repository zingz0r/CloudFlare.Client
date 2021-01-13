using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Enumerators;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Zones
{
    public class ZonesUnitTests
    {
        [Theory(Skip = "Would cause new zone")]
        [InlineData(@"test_domain_full.com", ZoneType.Full)]
        [InlineData(@"test_domain_partial.com", ZoneType.Partial)]
        public async Task TestCreateZoneAsync(string name, ZoneType type)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var account = (await client.Accounts.GetAsync()).Result.First();
            var zonesQueryResult = await client.Zones.AddAsync(name, type, account);

            zonesQueryResult.Should().NotBeNull();
            zonesQueryResult.Errors?.Should().BeEmpty();
            zonesQueryResult.Success.Should().BeTrue();
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
        public async Task TestGetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage, OrderType? order, bool? match)
        {
            var filter = new ZoneFilter
            {
                Name = name,
                Match = match,
                Status = status
            };
            var displayOptions = new DisplayOptions { Page = page, PerPage = perPage, Order = order };

            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = await client.Zones.GetAsync(filter, displayOptions);

            zonesQueryResult.Should().NotBeNull();
            zonesQueryResult.Errors?.Should().BeEmpty();
            zonesQueryResult.Success.Should().BeTrue();
        }

        [Fact]
        public async Task TestGetZoneDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.Zones.GetAsync()).Result.First();
            var zoneDetailsQueryResult = await client.Zones.GetDetailsAsync(zonesQueryResult.Id);

            zoneDetailsQueryResult.Should().NotBeNull();
            zoneDetailsQueryResult.Errors?.Should().BeEmpty();
            zoneDetailsQueryResult.Success.Should().BeTrue();
        }

        [Fact]
        public async Task TestEditZoneAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zone = (await client.Zones.GetAsync()).Result.First();
            var editZone = await client.Zones.UpdateAsync(zone.Id, new ModifiedZone
            {
                Plan = new Plan
                {
                    Id = zone.Plan.Id,
                    Currency = "USD"
                }
            });

            editZone.Should().NotBeNull();
            editZone.Errors?.Should().BeEmpty();
            editZone.Success.Should().BeTrue();
        }

        [Fact(Skip = "Would cause deleted zone")]

        public async Task TestDeleteZoneAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.Zones.GetAsync()).Result.First();
            var deletedZoneQueryResult = await client.Zones.DeleteAsync(zonesQueryResult.Id);

            deletedZoneQueryResult.Should().NotBeNull();
            deletedZoneQueryResult.Errors?.Should().BeEmpty();
            deletedZoneQueryResult.Success.Should().BeTrue();
        }

        [Fact]
        public async Task TestZoneActivationCheckAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.Zones.GetAsync()).Result.First();
            var zoneActivationCheckQueryResult = await client.Zones.CheckActivationAsync(zonesQueryResult.Id);

            zoneActivationCheckQueryResult.Should().NotBeNull();

            var notAvailable = new List<int>
            {
                1224, // You may only perform this action once per hour.
            };

            if (!zoneActivationCheckQueryResult.Errors.Any(x => notAvailable.Contains(x.Code)))
            {
                zoneActivationCheckQueryResult.Success.Should().BeTrue();
                zoneActivationCheckQueryResult.Errors?.Should().BeEmpty();
            }
        }

        [Fact]

        public async Task TestPurgeAllFilesAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.Zones.GetAsync()).Result.First();
            var purgeAllFilesAsyncQueryResult = await client.Zones.PurgeAllFilesAsync(zonesQueryResult.Id, true);

            purgeAllFilesAsyncQueryResult.Should().NotBeNull();
            purgeAllFilesAsyncQueryResult.Errors?.Should().BeEmpty();
            purgeAllFilesAsyncQueryResult.Success.Should().BeTrue();
        }
    }
}
