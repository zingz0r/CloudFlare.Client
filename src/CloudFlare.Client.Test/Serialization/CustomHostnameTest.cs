using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class CustomHostnameTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new CustomHostname();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
        {
            "id", "hostname", "ssl" , "status", "custom_origin_server",
            "verification_errors", "ownership_verification",
            "ownership_verification_http", "created_at", "custom_metadata"
        });
    }
}
