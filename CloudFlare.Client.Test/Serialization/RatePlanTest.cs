using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class RatePlanTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new RatePlan();

            var serialized = JsonConvert.SerializeObject(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList().OrderBy(x => x);

            keys.Should().BeEquivalentTo(new List<string> { "id", "public_name", "currency", "scope", "sets", "is_contract", "externally_managed" }.OrderBy(x => x));
        }
    }
}