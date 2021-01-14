using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class SslTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new Ssl();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
            {
                "status", "method", "type", "cname_target", "cname", "settings"
            });
        }
    }
}