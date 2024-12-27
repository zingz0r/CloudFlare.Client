using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators;

public class ZoneTypeTest
{
    [Fact]
    public void TestSerialization()
    {
        JsonHelper.GetSerializedEnums<ZoneType>().Should().BeEquivalentTo(new SortedSet<string> { "full", "partial" });
    }
}
