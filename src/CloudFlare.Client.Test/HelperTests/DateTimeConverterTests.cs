using System;
using CloudFlare.Client.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace CloudFlare.Client.Test.HelperTests;

public class DateTimeConverterTests
{

    private readonly DateTimeConverter _timeConverter = new("yyyy-MM-dd HH:mm:ss zzz 'UTC'", true);

    [Fact]
    public void ReadJson_ValidDate_ReturnsDateTime()
    {
        const string json = "\"2025-02-18 12:20:00 +0000 UTC\"";
        DateTime? expected = new DateTime(2025, 2, 18, 12, 20, 0, DateTimeKind.Utc);

        var result = JsonConvert.DeserializeObject<DateTime?>(json, _timeConverter);
        
        result.Should().NotBeNull();
        result.Should().Be(expected);
    }

    [Fact]
    public void ReadJson_InvalidDate_ThrowsException()
    {
        const string json = "\"2025-02-18 +0000 UTC\"";

        FluentActions.Invoking(() => JsonConvert.DeserializeObject<DateTime?>(json, _timeConverter))
            .Should().Throw<JsonSerializationException>();
    }

    [Fact]
    public void ReadJson_NullValue_ReturnsNull()
    {
        const string json = "null";
        
        var result = JsonConvert.DeserializeObject<DateTime?>(json, _timeConverter);
        
        result.Should().BeNull();
    }

    [Fact]
    public void WriteJson_ValidDate_SerializesCorrectly()
    {
        DateTime? date = new DateTime(2025, 2, 18, 12, 20, 0, DateTimeKind.Utc);
        const string expectedJson = "\"2025-02-18 12:20:00 +0000 UTC\"";

        string resultJson = JsonConvert.SerializeObject(date, _timeConverter);
        
        resultJson.Should().Be(expectedJson);
    }

    [Fact]
    public void WriteJson_NullValue_SerializesToNull()
    {
        DateTime? date = null;
        const string expectedJson = "null";

        string resultJson = JsonConvert.SerializeObject(date, _timeConverter);
        
        resultJson.Should().Be(expectedJson);
    }
}

