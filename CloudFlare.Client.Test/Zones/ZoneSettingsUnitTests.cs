﻿using System;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Zones;

public class ZoneSettingsUnitTests
{
    private readonly WireMockServer _wireMockServer;
    private readonly ConnectionInfo _connectionInfo;

    public ZoneSettingsUnitTests()
    {
        _wireMockServer = WireMockServer.Start();
        _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
    }

    [Theory]
    [InlineData(FeatureStatus.On)]
    [InlineData(FeatureStatus.Off)]
    public async Task TestGetAlwaysUseHttpsAsync(FeatureStatus setting)
    {
        var zone = ZoneTestData.Zones.First();
        var zoneSetting = new ZoneSetting<FeatureStatus>
        {
            Id = Guid.NewGuid().ToString(),
            Value = setting,
            ModifiedDate = DateTime.UtcNow,
            ValidationErrors = Array.Empty<ErrorDetails>()
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.AlwaysUseHttps}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(zoneSetting)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.Settings.GetAlwaysUseHttpsSettingAsync(zone.Id);

        result.Result.Should().BeEquivalentTo(zoneSetting);
    }

    [Theory]
    [InlineData(FeatureStatus.On)]
    [InlineData(FeatureStatus.Off)]
    public async Task TestUpdateAlwaysUseHttpsAsync(FeatureStatus setting)
    {
        var zone = ZoneTestData.Zones.First();
        var zoneSetting = new ZoneSetting<FeatureStatus>
        {
            Id = Guid.NewGuid().ToString(),
            Value = setting,
            ModifiedDate = DateTime.UtcNow,
            ValidationErrors = Array.Empty<ErrorDetails>()
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.AlwaysUseHttps}").UsingPatch())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(zoneSetting)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.Settings.UpdateAlwaysUseHttpsSettingAsync(zone.Id, setting);

        result.Result.Should().BeEquivalentTo(zoneSetting);
    }

    [Theory]
    [InlineData(SslSetting.Flexible)]
    [InlineData(SslSetting.Full)]
    [InlineData(SslSetting.Strict)]
    [InlineData(SslSetting.Off)]
    public async Task TestGetSslSettingsAsync(SslSetting setting)
    {
        var zone = ZoneTestData.Zones.First();
        var zoneSetting = new ZoneSetting<SslSetting>
        {
            Id = Guid.NewGuid().ToString(),
            Value = setting,
            ModifiedDate = DateTime.UtcNow,
            CertificateStatus = "active",
            ValidationErrors = Array.Empty<ErrorDetails>(),
            Editable = true
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.Ssl}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(zoneSetting)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.Settings.GetSslSettingAsync(zone.Id);

        result.Result.Should().BeEquivalentTo(zoneSetting);
    }

    [Theory]
    [InlineData(SslSetting.Flexible)]
    [InlineData(SslSetting.Full)]
    [InlineData(SslSetting.Strict)]
    [InlineData(SslSetting.Off)]
    public async Task TestUpdateSslSettingsAsync(SslSetting setting)
    {
        var zone = ZoneTestData.Zones.First();
        var zoneSetting = new ZoneSetting<SslSetting>
        {
            Id = Guid.NewGuid().ToString(),
            Value = setting,
            ModifiedDate = DateTime.UtcNow,
            CertificateStatus = "active",
            ValidationErrors = Array.Empty<ErrorDetails>(),
            Editable = true
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.Ssl}").UsingPatch())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(zoneSetting)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.Settings.UpdateSslSettingAsync(zone.Id, setting);

        result.Result.Should().BeEquivalentTo(zoneSetting);
    }

    [Theory]
    [InlineData(TlsVersion.Tls10)]
    [InlineData(TlsVersion.Tls11)]
    [InlineData(TlsVersion.Tls12)]
    [InlineData(TlsVersion.Tls13)]
    public async Task TestGetMinimumTlsVersionSettingAsync(TlsVersion version)
    {
        var zone = ZoneTestData.Zones.First();
        var zoneSetting = new ZoneSetting<TlsVersion>
        {
            Id = Guid.NewGuid().ToString(),
            Value = version,
            ModifiedDate = DateTime.UtcNow,
            ValidationErrors = Array.Empty<ErrorDetails>(),
            Editable = true
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.MinimumTlsVersion}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(zoneSetting)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.Settings.GetMinimumTlsVersionSettingAsync(zone.Id);

        result.Result.Should().BeEquivalentTo(zoneSetting);
    }

    [Theory]
    [InlineData(TlsVersion.Tls10)]
    [InlineData(TlsVersion.Tls11)]
    [InlineData(TlsVersion.Tls12)]
    [InlineData(TlsVersion.Tls13)]
    public async Task TestUpdateMinimumTlsVersionSettingAsync(TlsVersion version)
    {
        var zone = ZoneTestData.Zones.First();
        var zoneSetting = new ZoneSetting<TlsVersion>
        {
            Id = Guid.NewGuid().ToString(),
            Value = version,
            ModifiedDate = DateTime.UtcNow,
            ValidationErrors = Array.Empty<ErrorDetails>(),
            Editable = true
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{SettingsEndpoints.Base}/{SettingsEndpoints.MinimumTlsVersion}").UsingPatch())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(zoneSetting)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var result = await client.Zones.Settings.UpdateMinimumTlsVersionSettingAsync(zone.Id, version);

        result.Result.Should().BeEquivalentTo(zoneSetting);
    }
}
