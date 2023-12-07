using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Accounts.TurnstileWidgets;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class NewTurnstileWidgetTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new NewTurnstileWidget();

            var serialized = JsonConvert.SerializeObject(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList();

            keys.Should().BeEquivalentTo(new SortedSet<string>
            {
                "bot_fight_mode", "clearance_level", "domains", "mode",
                "name", "offlabel", "region"
            });
        }
    }
}