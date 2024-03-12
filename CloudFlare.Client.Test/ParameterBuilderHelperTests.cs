using System.Linq;
using System.Text.Json;
using System.Web;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Helpers;
using FluentAssertions;
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
        public void TestParameterBuilder(string key, object value)
        {
            var expected = HttpUtility.UrlDecode(JsonSerializer.Serialize(value).Replace("\"", ""));

            var builder = new ParameterBuilderHelper();

            builder.InsertValue(key, value);

            builder.ParameterCollection.AllKeys.Length.Should().Be(1);
            builder.ParameterCollection.AllKeys.First().Should().Be(key);

            builder.ParameterCollection.GetValues(0).Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("", 1)]
        [InlineData(null, 1)]
        [InlineData("", 3.0)]
        [InlineData(null, 3.0)]
        [InlineData("key", null)]
        [InlineData("key", "")]
        public void TestParameterBuilderWithDefaults(string key, object value)
        {
            var builder = new ParameterBuilderHelper();

            builder.InsertValue(key, value);

            builder.ParameterCollection.AllKeys.Should().BeEmpty();
        }
    }
}
