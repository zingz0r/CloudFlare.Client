﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using FluentAssertions;
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
        public async Task TestGetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage,
            OrderType? order, bool? match)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = await client.GetZonesAsync(name, status, page, perPage, order, match);

            zonesQueryResult.Should().NotBeNull();
            zonesQueryResult.Errors?.Should().BeEmpty();
            zonesQueryResult.Success.Should().BeTrue();
        }

        [Fact]
        public async Task TestGetZoneDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.GetZonesAsync()).Result.First();
            var zoneDetailsQueryResult = await client.GetZoneDetailsAsync(zonesQueryResult.Id);

            zoneDetailsQueryResult.Should().NotBeNull();
            zoneDetailsQueryResult.Errors?.Should().BeEmpty();
            zoneDetailsQueryResult.Success.Should().BeTrue();
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

            editZoneQueryResult.Should().NotBeNull();
            editZoneQueryResult.Errors?.Should().BeEmpty();
            editZoneQueryResult.Success.Should().BeTrue();
        }

        [Fact(Skip = "Would cause deleted zone")]

        public async Task TestDeleteZoneAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.GetZonesAsync()).Result.First();
            var deletedZoneQueryResult = await client.DeleteZoneAsync(zonesQueryResult.Id);

            deletedZoneQueryResult.Should().NotBeNull();
            deletedZoneQueryResult.Errors?.Should().BeEmpty();
            deletedZoneQueryResult.Success.Should().BeTrue();
        }

        [Fact]
        public async Task TestZoneActivationCheckAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = (await client.GetZonesAsync()).Result.First();
            var zoneActivationCheckQueryResult = await client.ZoneActivationCheckAsync(zonesQueryResult.Id);

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
            var zonesQueryResult = (await client.GetZonesAsync()).Result.First();
            var purgeAllFilesAsyncQueryResult = await client.PurgeAllFilesAsync(zonesQueryResult.Id, true);

            purgeAllFilesAsyncQueryResult.Should().NotBeNull();
            purgeAllFilesAsyncQueryResult.Errors?.Should().BeEmpty();
            purgeAllFilesAsyncQueryResult.Success.Should().BeTrue();
        }
    }
}
