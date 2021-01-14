using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Result;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class ResultInfoTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new ResultInfo();

            var serialized = JsonConvert.SerializeObject(sut);

            var json = JObject.Parse(serialized);

            var keys = json.Properties().Select(p => p.Name).ToList().OrderBy(x => x);

            keys.Should().BeEquivalentTo(new List<string> { "page", "total_page", "per_page", "count", "total_count" }.OrderBy(x => x));
        }
    }
}