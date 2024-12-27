using System.Collections.Generic;
using CloudFlare.Client.Api;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class PermissionTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new Permission();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
        {
            "read", "write"
        });
    }
}
