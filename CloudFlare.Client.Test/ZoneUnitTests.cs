using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using CloudFlare.Client.Test.FactAttributes;
using CloudFlare.Client.Test.TheoryAttributes;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class ZoneUnitTests
    {
        [IgnoreOnEmptyCredentialsTheory(Skip = "Would cause new zone")]
        [InlineData(@"test_domain_full.com", ZoneType.Full)]
        [InlineData(@"test_domain_partial.com", ZoneType.Partial)]
        public void TestCreateZoneAsync(string name, ZoneType type)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var account = client.GetAccountsAsync().Result.Result.First();
            var zonesQueryResult = client.CreateZoneAsync(name, type, account).Result;

            Assert.NotNull(zonesQueryResult);
            Assert.Empty(zonesQueryResult.Errors);
            Assert.True(zonesQueryResult.Success);
        }

        [IgnoreOnEmptyCredentialsTheory]
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
        public void TestGetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage,
            OrderType? order, bool? match)
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = client.GetZonesAsync(name, status, page, perPage, order, match).Result;

            Assert.NotNull(zonesQueryResult);
            Assert.Empty(zonesQueryResult.Errors);
            Assert.True(zonesQueryResult.Success);
        }

        [IgnoreOnEmptyCredentialsFact]
        public void TestGetZoneDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = client.GetZonesAsync().Result.Result.First();
            var zoneDetailsQueryResult = client.GetZoneDetailsAsync(zonesQueryResult.Id).Result;

            Assert.NotNull(zoneDetailsQueryResult);
            Assert.Empty(zoneDetailsQueryResult.Errors);
            Assert.True(zoneDetailsQueryResult.Success);
        }

        [IgnoreOnEmptyCredentialsFact(Skip = "Would cause edited zone")]
        public void TestEditZoneAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = client.GetZonesAsync().Result.Result.First();
            var editZoneQueryResult = client.EditZoneAsync(zonesQueryResult.Id, new PatchZone
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
            }).Result;

            Assert.NotNull(editZoneQueryResult);
            Assert.Empty(editZoneQueryResult.Errors);
            Assert.True(editZoneQueryResult.Success);
        }

        [IgnoreOnEmptyCredentialsFact(Skip = "Would cause deleted zone")]

        public void TestDeleteZoneAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = client.GetZonesAsync().Result.Result.First();
            var deletedZoneQueryResult = client.DeleteZoneAsync(zonesQueryResult.Id).Result;

            Assert.NotNull(deletedZoneQueryResult);
            Assert.Empty(deletedZoneQueryResult.Errors);
            Assert.True(deletedZoneQueryResult.Success);
        }

        [IgnoreOnEmptyCredentialsFact]

        public void TestZoneActivationCheckAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = client.GetZonesAsync().Result.Result.First();
            var zoneActivationCheckQueryResult = client.ZoneActivationCheckAsync(zonesQueryResult.Id).Result;

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

        [IgnoreOnEmptyCredentialsFact]

        public void TestPurgeAllFilesAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zonesQueryResult = client.GetZonesAsync().Result.Result.First();
            var purgeAllFilesAsyncQueryResult = client.PurgeAllFilesAsync(zonesQueryResult.Id, true).Result;

            Assert.NotNull(purgeAllFilesAsyncQueryResult);
            Assert.Empty(purgeAllFilesAsyncQueryResult.Errors);
            Assert.True(purgeAllFilesAsyncQueryResult.Success);
        }
    }
}
