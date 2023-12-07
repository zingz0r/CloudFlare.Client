using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Zones.WorkerRoute;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class WorkerRouteTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new WorkerRoute();

            var serialized = JsonConvert.SerializeObject(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList();

            keys.Should().BeEquivalentTo(new SortedSet<string>
            {
                "id", "pattern", "script"
            });
        }
    }
}