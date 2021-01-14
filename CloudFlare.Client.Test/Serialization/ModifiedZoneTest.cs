using System.Collections.Generic;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class ModifiedZoneTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new ModifiedZone();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "vanity_name_servers", "paused", "plan" });
        }
    }
}