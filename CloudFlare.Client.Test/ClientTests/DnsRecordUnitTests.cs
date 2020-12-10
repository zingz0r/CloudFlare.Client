using System;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Enumerators;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests
{
    public class DnsRecordUnitTests
    {
        [Fact]
        public async Task TestCreateDnsRecordAsyncDeleteDnsRecordAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zone = (await client.GetZonesAsync()).Result.First();

            var create = await client.CreateDnsRecordAsync(zone.Id, DnsRecordType.A, $"{Guid.NewGuid()}.{zone.Name}", "1.1.1.1");
            var delete = await client.DeleteDnsRecordAsync(zone.Id, create.Result.Id);

            create.Success.Should().BeTrue();
            create.Errors?.Should().BeEmpty();
            delete.Success.Should().BeTrue();
            delete.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestExportDnsRecordsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zone = (await client.GetZonesAsync()).Result.First();

            var export = await client.ExportDnsRecordsAsync(zone.Id);

            export.Success.Should().BeTrue();
            export.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetDnsRecordsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zone = (await client.GetZonesAsync()).Result.First();
            var records = (await client.GetDnsRecordsAsync(zone.Id));

            records.Success.Should().BeTrue();
            records.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetDnsRecordDetailsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zone = (await client.GetZonesAsync()).Result.First();
            var record = (await client.GetDnsRecordsAsync(zone.Id)).Result.First();

            var recordDetails = await client.GetDnsRecordDetailsAsync(zone.Id, record.Id);

            recordDetails.Success.Should().BeTrue();
            recordDetails.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestScanDnsRecordsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zone = (await client.GetZonesAsync()).Result.First();
            var scanZone = await client.ScanDnsRecordsAsync(zone.Id);

            scanZone.Errors?.Should().BeEmpty();
            scanZone.Success.Should().BeTrue();
        }

        [Fact]
        public async Task TestUpdateDnsRecordAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zone = (await client.GetZonesAsync()).Result.First();
            var record = (await client.GetDnsRecordsAsync(zone.Id)).Result.First();

            var update = await client.UpdateDnsRecordAsync(zone.Id, record.Id, record.Type, record.Name, record.Content);

            update.Errors?.Should().BeEmpty();
            update.Success.Should().BeTrue();
        }
    }
}