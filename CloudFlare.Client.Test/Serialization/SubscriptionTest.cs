using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class SubscriptionTest
{
    [Fact]
    public void TestSerialization()
    {
        var sut = new Subscription();

        var serialized = JsonConvert.SerializeObject(sut);

        var json = JObject.Parse(serialized);

        var keys = json.Properties().Select(p => p.Name).ToList();

        keys.Should().BeEquivalentTo(new SortedSet<string>
        {
            "app", "id", "state", "price", "currency", "component_values",
            "zone", "frequency", "rate_plan", "current_period_end", "current_period_start"
        });
    }
}