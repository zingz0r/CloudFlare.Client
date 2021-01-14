using System.Collections.Generic;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class PlanTest
    {

        [Fact]
        public void TestSerialization()
        {
            var sut = new Plan();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string>
            {
                "id", "name", "price", "currency", "frequency", "legacy_id", "is_subscribed", "can_subscribe"
            });
        }
    }
}