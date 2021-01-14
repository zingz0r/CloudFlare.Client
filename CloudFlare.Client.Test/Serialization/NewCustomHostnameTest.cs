using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class NewCustomHostnameTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new NewCustomHostname();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "ssl", "hostname" });
        }
    }
}