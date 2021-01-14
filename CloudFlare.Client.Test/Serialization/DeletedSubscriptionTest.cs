using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class DeletedSubscriptionTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new DeletedSubscription();

            var serialized = JsonConvert.SerializeObject(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList().OrderBy(x => x);

            keys.Should().BeEquivalentTo(new List<string> { "subscription_id" }.OrderBy(x => x));
        }
    }
}