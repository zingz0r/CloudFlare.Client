using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.DnsRecord;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class DnsRecordTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new DnsRecord();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> {
                "id", "type", "name", "comment", "content", "proxiable", "proxied",
                "priority", "ttl", "locked", "zone_id", "zone_name",
                "created_on", "modified_on", "comment_modified_on", "tags_modified_on", "data"
            });
        }
    }
}
