using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests
{
    public class DnsRecordUnitTests
    {
        [Fact]
        public async Task CreateDelete()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zone = (await client.GetZonesAsync()).Result.First();

            false.Should().BeTrue();
        }

        [Fact]
        public async Task TestScanDnsRecordsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zone = (await client.GetZonesAsync()).Result.First();
            var scanZone = await client.ScanDnsRecordsAsync(zone.Id);

            scanZone.Should().NotBeNull();
            scanZone.Errors?.Should().BeEmpty();
            scanZone.Success.Should().BeTrue();
        }
    }
}