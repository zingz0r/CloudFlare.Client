using System.Collections.Generic;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class NewZoneTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new NewZone();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "name", "jump_start", "type", "account" });
    }
}