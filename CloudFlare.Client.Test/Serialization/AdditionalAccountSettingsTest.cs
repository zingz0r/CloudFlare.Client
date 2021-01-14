using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class AdditionalAccountSettingsTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new AdditionalAccountSettings();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "enforce_twofactor", "access_approval_expiry" });
        }
    }
}