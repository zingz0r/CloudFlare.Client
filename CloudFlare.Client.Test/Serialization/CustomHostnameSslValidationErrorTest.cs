using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class CustomHostnameSslValidationErrorTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new CustomHostnameSslValidationError();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "message" });
    }
}