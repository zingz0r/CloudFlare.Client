using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using CloudFlare.Client.Api.Accounts.TurnstileWidgets;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class TurnstileWidgetTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new TurnstileWidget();

            var serialized = JsonSerializer.Serialize(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList();

            keys.Should().BeEquivalentTo(new SortedSet<string>
            {
                "sitekey", "bot_fight_mode", "clearance_level", "created_on", "domains", "mode",
                "modified_on", "name", "offlabel", "region", "secret"
            });
        }
    }
}