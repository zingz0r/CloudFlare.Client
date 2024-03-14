using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using CloudFlare.Client.Contexts;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class SubscriptionTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new Subscription();

            var serialized = JsonSerializer.Serialize(sut, CloudFlareJsonSerializerContext.Default.Subscription);

            var json = JsonObject.Parse(serialized) as IDictionary<string, JsonNode>;

            var keys = json.Keys.ToList();

            keys.Should().BeEquivalentTo(new SortedSet<string>
            {
                "app", "id", "state", "price", "currency", "component_values",
                "zone", "frequency", "rate_plan", "current_period_end", "current_period_start"
            });
        }
    }
}