using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using CloudFlare.Client.Api.Accounts.TurnstileWidgets;
using CloudFlare.Client.Contexts;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class TurnstileWidgetTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new TurnstileWidget();

            var serialized = JsonSerializer.Serialize(sut, CloudFlareJsonSerializerContext.Default.TurnstileWidget);

            var json = JsonObject.Parse(serialized) as IDictionary<string, JsonNode>;

            var keys = json.Keys.ToList();

            keys.Should().BeEquivalentTo(new SortedSet<string>
            {
                "sitekey", "bot_fight_mode", "clearance_level", "created_on", "domains", "mode",
                "modified_on", "name", "offlabel", "region", "secret"
            });
        }
    }
}