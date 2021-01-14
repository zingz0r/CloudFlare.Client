using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Users;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class VerifyTokenTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new VerifyToken();

            var serialized = JsonConvert.SerializeObject(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList().OrderBy(x => x);

            keys.Should().BeEquivalentTo(new List<string> { "id", "name", "status", "expires_on", "issued_on", "modified_on", "not_before" }.OrderBy(x => x));
        }
    }
}