using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class ComponentValueTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new ComponentValue();

            var serialized = JsonConvert.SerializeObject(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList().OrderBy(x => x);

            keys.Should().BeEquivalentTo(new List<string> { "name", "value", "default", "price" }.OrderBy(x => x));
        }
    }
}