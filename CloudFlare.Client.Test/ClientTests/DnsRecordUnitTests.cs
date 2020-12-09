using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CloudFlare.Client.Test.ClientTests
{
    public class DnsRecordUnitTests
    {
        [Fact]
        public async Task TestScanDnsRecordsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var zone = (await client.GetZonesAsync()).Result.First();
            var scanZone = await client.ScanDnsRecordsAsync(zone.Id);

            Assert.NotNull(scanZone);
            Assert.Empty(scanZone.Errors);
            Assert.True(scanZone.Success);
        }
    }
}