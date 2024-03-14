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
    public class NewTurnstileWidgetTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new NewTurnstileWidget();

            var serialized = JsonSerializer.Serialize(sut, CloudFlareJsonSerializerContext.Default.NewTurnstileWidget);

            var json = JsonObject.Parse(serialized) as IDictionary<string, JsonNode>;

            var keys = json.Keys.ToList();

            keys.Should().BeEquivalentTo(new SortedSet<string>
            {
                "bot_fight_mode", "clearance_level", "domains", "mode",
                "name", "offlabel", "region"
            });
        }
    }
}