using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators;

public class OwnerTypeTest
{
    [Fact]
    public void TestSerialization()
    {
        JsonHelper.GetSerializedEnums<OwnerType>().Should().BeEquivalentTo(new SortedSet<string> { "organization", "user" });
    }
}
