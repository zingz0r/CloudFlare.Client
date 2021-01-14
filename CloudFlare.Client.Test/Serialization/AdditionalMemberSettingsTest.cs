using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Accounts.Member;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class AdditionalMemberSettingsTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new AdditionalMemberSettings();

            var serialized = JsonConvert.SerializeObject(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList().OrderBy(x => x);

            keys.Should().BeEquivalentTo(new List<string> { "code", "user", "status" }.OrderBy(x => x));
        }
    }
}