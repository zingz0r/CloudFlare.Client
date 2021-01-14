using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class AdditionalCustomHostnameSslSettingsTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new AdditionalCustomHostnameSslSettings();

            var serialized = JsonConvert.SerializeObject(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList().OrderBy(x => x);

            keys.Should().BeEquivalentTo(new List<string> { "http2", "min_tls_version", "tls_1_3", "ciphers" }.OrderBy(x => x));
        }
    }
}