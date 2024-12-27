using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators;

public class MethodTypeTest
{
    [Fact]
    public void TestSerialization()
    {
        JsonHelper.GetSerializedEnums<MethodType>().Should().BeEquivalentTo(new SortedSet<string> { "http", "email", "cname", "txt" });
    }
}
