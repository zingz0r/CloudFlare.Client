using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.DnsRecord;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class DnsRecordScanTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new DnsRecordScan();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "recs_added_by_type", "total_records_parsed", "recs_added" });
        }
    }
}