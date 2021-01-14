using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class EnterpriseZoneQuotaTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new EnterpriseZoneQuota();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "maximum", "current", "available" });
        }
    }
}