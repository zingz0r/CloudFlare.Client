using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.DnsRecord;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class DnsRecordImportTest
    {

        [Fact]
        public void TestSerialization()
        {
            var sut = new DnsRecordImport();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "total_records_parsed", "recs_added" });
        }
    }
}