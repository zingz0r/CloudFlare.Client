﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Types;
using Xunit;

namespace CloudFlare.Client.Test;

public class AuthenticationTests
{
    private readonly WireMockServer _wireMockServer;
    private readonly ConnectionInfo _connectionInfo;

    public AuthenticationTests()
    {
        _wireMockServer = WireMockServer.Start();
        _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
    }

    [Fact]
    public async Task TestClientAuthenticationWithApiKeyAuthentication()
    {
        var user = UserTestData.Users.First();

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        IDictionary<string, WireMockList<string>> headers = null;

        _wireMockServer
            .Given(Request.Create().WithPath($"/{UserEndpoints.Base}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(x =>
                {
                    headers = x.Headers;
                    return WireMockResponseHelper.CreateTestResponse(user);
                }));

        await client.Users.GetDetailsAsync();

        headers.Should().ContainKey("X-Auth-Email");
        headers.First(x => x.Key == "X-Auth-Email").Value.Should().BeEquivalentTo(WireMockConnection.EmailAddress);

        headers.Should().ContainKey("X-Auth-Key");
        headers.First(x => x.Key == "X-Auth-Key").Value.Should().BeEquivalentTo(WireMockConnection.Key);
    }

    [Fact]
    public async Task TestClientAuthenticationWithApiKey()
    {
        var user = UserTestData.Users.First();

        using var client = new CloudFlareClient(WireMockConnection.EmailAddress, WireMockConnection.Key, _connectionInfo);

        IDictionary<string, WireMockList<string>> headers = null;

        _wireMockServer
            .Given(Request.Create().WithPath($"/{UserEndpoints.Base}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(x =>
                {
                    headers = x.Headers;
                    return WireMockResponseHelper.CreateTestResponse(user);
                }));

        await client.Users.GetDetailsAsync();

        headers.Should().ContainKey("X-Auth-Email");
        headers.First(x => x.Key == "X-Auth-Email").Value.Should().BeEquivalentTo(WireMockConnection.EmailAddress);

        headers.Should().ContainKey("X-Auth-Key");
        headers.First(x => x.Key == "X-Auth-Key").Value.Should().BeEquivalentTo(WireMockConnection.Key);
    }

    [Fact]
    public async Task TestClientAuthenticationWithTokenAuthentication()
    {
        var user = UserTestData.Users.First();

        using var client = new CloudFlareClient(WireMockConnection.ApiTokenAuthentication, _connectionInfo);

        IDictionary<string, WireMockList<string>> headers = null;

        _wireMockServer
            .Given(Request.Create().WithPath($"/{UserEndpoints.Base}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(x =>
                {
                    headers = x.Headers;
                    return WireMockResponseHelper.CreateTestResponse(user);
                }));

        await client.Users.GetDetailsAsync();
        headers.Should().ContainKey("Authorization");
        headers.First(x => x.Key == "Authorization").Value.Should().BeEquivalentTo($"Bearer {WireMockConnection.Token}");
    }

    [Fact]
    public async Task TestClientAuthenticationWithToken()
    {
        var user = UserTestData.Users.First();

        using var client = new CloudFlareClient(WireMockConnection.Token, _connectionInfo);

        IDictionary<string, WireMockList<string>> headers = null;

        _wireMockServer
            .Given(Request.Create().WithPath($"/{UserEndpoints.Base}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(x =>
                {
                    headers = x.Headers;
                    return WireMockResponseHelper.CreateTestResponse(user);
                }));

        await client.Users.GetDetailsAsync();
        headers.Should().ContainKey("Authorization");
        headers.First(x => x.Key == "Authorization").Value.Should().BeEquivalentTo($"Bearer {WireMockConnection.Token}");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void TestClientAuthenticationWithApiToken(string token)
    {
        Func<CloudFlareClient> ctor = () => new CloudFlareClient(token);
        ctor.Should().ThrowExactly<AuthenticationException>();
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("email", "")]
    [InlineData("email", null)]
    [InlineData("", "password")]
    [InlineData(null, "password")]
    public void TestClientAuthenticationWithAuthObject(string email, string key)
    {
        Func<CloudFlareClient> ctor = () => new CloudFlareClient(email, key);
        ctor.Should().ThrowExactly<AuthenticationException>();
    }
}
