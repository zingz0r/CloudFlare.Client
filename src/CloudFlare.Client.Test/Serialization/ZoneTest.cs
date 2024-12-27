using System.Collections.Generic;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class ZoneTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new Zone();

        JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
        {
            "id", "name", "development_mode", "original_name_servers", "original_registrar",
            "original_dnshost", "created_on", "modified_on", "activated_on", "owner",
            "account", "permissions", "plan", "plan_pending", "status",
            "paused", "type", "name_servers"
        });
    }
}