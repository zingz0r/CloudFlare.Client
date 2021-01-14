using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class RatePlanTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new RatePlan();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
            {
                "id", "public_name", "currency", "scope", "sets", "is_contract", "externally_managed"
            });
        }
    }
}