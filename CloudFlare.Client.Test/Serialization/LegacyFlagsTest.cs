using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class LegacyFlagsTest
    {

        [Fact]
        public void TestSerialization()
        {
            var sut = new LegacyFlags();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "enterprise_zone_quota" });
        }
    }
}