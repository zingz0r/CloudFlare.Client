using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators;

public class RegionTest
{
    [Fact]
    public void TestSerialization()
    {
        JsonHelper.GetSerializedEnums<Region>().Should().BeEquivalentTo(new SortedSet<string> { "world" });
    }
}