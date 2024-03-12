using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using CloudFlare.Client.Api.Zones.WorkerRoute;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class WorkerRouteTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new WorkerRoute();

            var serialized = JsonSerializer.Serialize(sut);

            var json = JsonObject.Parse(serialized) as IDictionary<string, JsonNode>;

            var keys = json.Keys.ToList();

            keys.Should().BeEquivalentTo(new SortedSet<string>
            {
                "id", "pattern", "script"
            });
        }
    }
}