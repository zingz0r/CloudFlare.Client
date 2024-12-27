using System.Collections.Generic;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class OwnerTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new Owner();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "type", "email", "id" });
    }
}
