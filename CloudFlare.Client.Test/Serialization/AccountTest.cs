using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class AccountTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new Account();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "id", "name", "settings", "type", "created_on", "legacy_flags" });
        }
    }
}