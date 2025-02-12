using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class OwnershipVerificationHttpTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new OwnershipVerificationHttp();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "http_body", "http_url" });
    }
}
