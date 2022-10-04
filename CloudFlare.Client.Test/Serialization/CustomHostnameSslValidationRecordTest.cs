using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class CustomHostnameSslValidationRecordTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new CustomHostnameSslValidationRecord();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "txt_name", "txt_value", "http_url", "http_body", "emails" });
    }
}