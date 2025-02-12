using System;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Parameters;
using CloudFlare.Client.Api.Parameters.Data;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Zones.DnsRecord;
using CloudFlare.Client.Contexts;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Zones;

public class DnsRecordUnitTests
{
    private readonly WireMockServer _wireMockServer;
    private readonly ConnectionInfo _connectionInfo;

    public DnsRecordUnitTests()
    {
        _wireMockServer = WireMockServer.Start();
        _connectionInfo = new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo;
    }

    [Fact]
    public async Task TestCreateDnsRecordAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var dnsRecord = DnsRecordTestData.DnsRecords.First();
        var newRecord = new NewDnsRecord
        {
            Name = dnsRecord.Name,
            Content = dnsRecord.Content,
            Comment = dnsRecord.Comment,
            Tags = dnsRecord.Tags,
            Priority = dnsRecord.Priority,
            Proxied = dnsRecord.Proxied,
            Ttl = dnsRecord.Ttl,
            Type = dnsRecord.Type
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{DnsRecordEndpoints.Base}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(dnsRecord)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var created = await client.Zones.DnsRecords.AddAsync(zone.Id, newRecord);

        created.Result.Should().BeEquivalentTo(dnsRecord);
    }

    [Fact]
    public async Task TestCreateSrvDataDnsRecordAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var newRecord = new NewDnsRecord<Srv>
        {
            Type = DnsRecordType.Srv,
            Data = new()
            {
                Name = "@",
                Port = 1234,
                Priority = 5,
                Protocol = Protocol.Tcp,
                Service = "_servicename",
                Target = "servicename.tothnet.hu",
                Weight = 5
            },
            Proxied = true,
            Ttl = 12,
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{DnsRecordEndpoints.Base}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(x =>
                {
                    var dnsRecord = DnsRecordTestData.DnsRecords.First().DeepClone();
                    dnsRecord.Type = newRecord.Type;
                    dnsRecord.Priority = newRecord.Data.Priority;
                    dnsRecord.Data = newRecord.Data;
                    return WireMockResponseHelper.CreateTestResponse(dnsRecord);
                }));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var created = await client.Zones.DnsRecords.AddAsync(zone.Id, newRecord);

        created.Result.Should().BeEquivalentTo(DnsRecordTestData.DnsRecords.First(),
            c => c.Excluding(p => p.Data)
                .Excluding(p => p.Type)
                .Excluding(p => p.Priority));
        JsonConvert.DeserializeObject<Srv>(created.Result.Data.ToString()).Should().BeEquivalentTo(newRecord.Data);
        created.Result.Type.Should().Be(newRecord.Type);
        created.Result.Priority.Should().Be(newRecord.Data.Priority);
    }

    [Fact]
    public async Task TestCreateTlsaDataDnsRecordAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var newRecord = new NewDnsRecord<TlsA>
        {
            Type = DnsRecordType.TlsA,
            Data = new()
            {
                Certificate = "G7xPqBbk8UqCrcm2D5QsDkym3zPQd6wyf3mZ4kU24DtWzfCSh945M6qcqHwseaBbmR",
                MatchingType = 0,
                Selector = 0,
                Usage = 1
            },
            Proxied = false,
            Ttl = 12,
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{DnsRecordEndpoints.Base}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(x =>
                {
                    var dnsRecord = DnsRecordTestData.DnsRecords.First().DeepClone();
                    dnsRecord.Type = newRecord.Type;
                    dnsRecord.Data = newRecord.Data;
                    return WireMockResponseHelper.CreateTestResponse(dnsRecord);
                }));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var created = await client.Zones.DnsRecords.AddAsync(zone.Id, newRecord);

        created.Result.Should().BeEquivalentTo(DnsRecordTestData.DnsRecords.First(),
            c => c.Excluding(p => p.Data)
                .Excluding(p => p.Type)
                .Excluding(p => p.Priority));

        JsonConvert.DeserializeObject<TlsA>(created.Result.Data.ToString()).Should().BeEquivalentTo(newRecord.Data);
        created.Result.Type.Should().Be(newRecord.Type);
    }

    [Fact]
    public async Task TestExportDnsRecordsAsync()
    {
        var zone = ZoneTestData.Zones.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{DnsRecordEndpoints.Base}/{DnsRecordEndpoints.Export}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(DnsRecordTestData.Export)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var export = await client.Zones.DnsRecords.ExportAsync(zone.Id);

        export.Result.Should().BeEquivalentTo(DnsRecordTestData.Export);
    }

    [Fact]
    public async Task TestGetDnsRecordsAsync()
    {
        var displayOptions = new DisplayOptions { Page = 1, PerPage = 20, Order = OrderType.Asc };
        var dnsRecordFilter = new DnsRecordFilter { Content = "127.0.0.1", Match = MatchType.All, Name = "tothnet.hu", Type = DnsRecordType.A };

        var zone = ZoneTestData.Zones.First();

        _wireMockServer
            .Given(Request.Create()
                .WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{DnsRecordEndpoints.Base}")
                .WithParam(Filtering.Page)
                .WithParam(Filtering.PerPage)
                .WithParam(Filtering.Order)
                .WithParam(Filtering.Name)
                .WithParam(Filtering.Content)
                .WithParam(Filtering.DnsRecordType)
                .UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(DnsRecordTestData.DnsRecords)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var records = await client.Zones.DnsRecords.GetAsync(zone.Id, dnsRecordFilter, displayOptions);

        records.Result.Should().BeEquivalentTo(DnsRecordTestData.DnsRecords);
    }

    [Fact]
    public async Task TestGetDnsRecordDetailsAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var record = DnsRecordTestData.DnsRecords.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{DnsRecordEndpoints.Base}/{record.Id}").UsingGet())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(record)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var recordDetails = await client.Zones.DnsRecords.GetDetailsAsync(zone.Id, record.Id);

        recordDetails.Result.Should().BeEquivalentTo(record);
    }

    [Fact]
    public async Task TestScanDnsRecordsAsync()
    {
        var zone = ZoneTestData.Zones.First();

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{DnsRecordEndpoints.Base}/{DnsRecordEndpoints.Scan}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(DnsRecordTestData.DnsRecordScans.First())));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var scanZone = await client.Zones.DnsRecords.ScanAsync(zone.Id);

        scanZone.Result.Should().BeEquivalentTo(DnsRecordTestData.DnsRecordScans.First());
    }

    [Fact]
    public async Task TestUpdateDnsRecordAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var record = DnsRecordTestData.DnsRecords.First();
        var modified = new ModifiedDnsRecord
        {
            Name = "new.tothnet.hu",
            Comment = "new comment",
            Tags = new[] { "1", "2" }
        };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{DnsRecordEndpoints.Base}/{record.Id}").UsingPut())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(x =>
                {
                    var body = JsonConvert.DeserializeObject<ModifiedDnsRecord>(x.Body ?? throw new InvalidOperationException());
                    var response = DnsRecordTestData.DnsRecords.First(y => y.Id == x.PathSegments[3]).DeepClone();
                    response.Name = body.Name;
                    response.Comment = body.Comment;
                    response.Tags = body.Tags;

                    return WireMockResponseHelper.CreateTestResponse(response);
                }));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var update = await client.Zones.DnsRecords.UpdateAsync(zone.Id, record.Id, modified);

        update.Result.Should().BeEquivalentTo(record, opt => opt
            .Excluding(x => x.Name)
            .Excluding(x => x.Comment)
            .Excluding(x => x.Tags));
        update.Result.Name.Should().BeEquivalentTo("new.tothnet.hu");
        update.Result.Comment.Should().BeEquivalentTo("new comment");
        update.Result.Tags.Count.Should().Be(2);
        update.Result.Tags.Should().BeEquivalentTo("1", "2");
    }

    [Fact]
    public async Task TestDeleteDnsRecordAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var record = DnsRecordTestData.DnsRecords.First();
        var expected = new DnsRecord() { Id = record.Id };

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{DnsRecordEndpoints.Base}/{record.Id}").UsingDelete())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(expected)));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var delete = await client.Zones.DnsRecords.DeleteAsync(zone.Id, record.Id);

        delete.Result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task TestImportDnsRecordAsync()
    {
        var zone = ZoneTestData.Zones.First();
        var file = FileHelper.CreateTempFile("test.txt");

        _wireMockServer
            .Given(Request.Create().WithPath($"/{ZoneEndpoints.Base}/{zone.Id}/{DnsRecordEndpoints.Base}/{DnsRecordEndpoints.Import}").UsingPost())
            .RespondWith(Response.Create().WithStatusCode(200)
                .WithBody(WireMockResponseHelper.CreateTestResponse(DnsRecordTestData.DnsRecordImports.First())));

        using var client = new CloudFlareClient(WireMockConnection.ApiKeyAuthentication, _connectionInfo);

        var import = await client.Zones.DnsRecords.ImportAsync(zone.Id, file, false);
        file.Delete();

        import.Result.Should().BeEquivalentTo(DnsRecordTestData.DnsRecordImports.First());
    }
}
