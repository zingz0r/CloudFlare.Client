using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class ModifiedCustomHostnameTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new ModifiedCustomHostname();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "ssl", "custom_origin_server", "custom_metadata" });
        }
    }
}