using System.Web;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace CloudFlare.Client.Test;

public class ParameterBuilderTests
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
        var expected = $"{key}={HttpUtility.UrlDecode(JsonConvert.SerializeObject(value).Replace("\"", ""))}";

        var parameters = new ParameterBuilder().InsertValue(key, value);

        parameters.ToString().Should().Be(expected);
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
        var parameters = new ParameterBuilder().InsertValue(key, value);

        parameters.ToString().Should().Be(string.Empty);
    }
}
