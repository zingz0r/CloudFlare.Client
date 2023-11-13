using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.DnsRecord;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class ModifiedDnsRecordTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new ModifiedDnsRecord();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "name", "content", "ttl", "proxied", "type", "priority" });
        }
    }
}