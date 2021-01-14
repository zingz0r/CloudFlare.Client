using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators
{
    public class ZoneStatusTest
    {
        [Fact]
        public void TestSerialization()
        {
            JsonHelper.GetSerializedEnums<ZoneStatus>().Should().BeEquivalentTo(new SortedSet<string>
            {
                "active", "pending", "initializing", "moved", "deleted", "deactivated"
            });
        }
    }
}