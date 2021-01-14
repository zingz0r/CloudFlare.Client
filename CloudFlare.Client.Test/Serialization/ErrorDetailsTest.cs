using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Result;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class ErrorDetailsTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new ErrorDetails();

            var serialized = JsonConvert.SerializeObject(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList().OrderBy(x => x);

            keys.Should().BeEquivalentTo(new List<string> { "code", "message" }.OrderBy(x => x));
        }
    }
}