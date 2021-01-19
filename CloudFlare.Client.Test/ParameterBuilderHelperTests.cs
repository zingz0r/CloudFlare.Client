using System.Linq;
using System.Web;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace CloudFlare.Client.Test
{
    public class ParameterBuilderHelperTests
    {
        [Theory]
        [InlineData("key", 1)]
        [InlineData("key", "hello")]
        [InlineData("key", 3.0)]
        [InlineData("key", true)]
        [InlineData("key", 'c')]
        [InlineData("key", ZoneStatus.Deactivated)]
        [InlineData("key", null)]
        public void TestParameterBuilder(string key, object value)
        {
            var expected = HttpUtility.UrlDecode(JsonConvert.SerializeObject(value).Replace("\"", ""));

            var builder = new ParameterBuilderHelper();

            builder.InsertValue(key, value);

            builder.ParameterCollection.AllKeys.Length.Should().Be(1);
            builder.ParameterCollection.AllKeys.First().Should().Be(key);

            builder.ParameterCollection.GetValues(0).Should().BeEquivalentTo(expected);
        }
    }
}
