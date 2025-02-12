using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class AdditionalCustomHostnameSslSettingsTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new AdditionalCustomHostnameSslSettings();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "http2", "min_tls_version", "tls_1_3", "ciphers" });
    }
}