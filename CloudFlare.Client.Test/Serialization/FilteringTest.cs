using CloudFlare.Client.Api.Parameters;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization;

public class FilteringTest
{
    [Fact]
    public void TestSerialization()
    {
        Filtering.Id.Should().Be("id");
        Filtering.AccountName.Should().Be("account.name");
        Filtering.Content.Should().Be("content");
        Filtering.Direction.Should().Be("direction");
        Filtering.DnsRecordType.Should().Be("type");
        Filtering.Hostname.Should().Be("hostname");
        Filtering.Match.Should().Be("match");
        Filtering.Name.Should().Be("name");
        Filtering.Order.Should().Be("order");
        Filtering.Page.Should().Be("page");
        Filtering.PerPage.Should().Be("per_page");
        Filtering.Proxied.Should().Be("proxied");
        Filtering.Ssl.Should().Be("ssl");
        Filtering.Status.Should().Be("status");
    }
}
