# CloudFlare.Client

[![Donate](https://img.shields.io/badge/donate-PayPal-blueviolet.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=zgmode%40gmail.com&currency_code=USD&source=url)
[![Nuget](https://img.shields.io/nuget/v/CloudFlare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)
[![Nuget](https://img.shields.io/nuget/dt/Cloudflare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)
[![Libraries.io](https://img.shields.io/librariesio/github/zingz0r/CloudFlare.Client.svg)](https://libraries.io/github/zingz0r/CloudFlare.Client)
[![GitHub issues](https://img.shields.io/github/issues-raw/zingz0r/Cloudflare.Client.svg)](https://github.com/zingz0r/CloudFlare.Client/issues)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

[![Build Status](https://zingzor.visualstudio.com/CloudFlare.Client/_apis/build/status/zingz0r.CloudFlare.Client?branchName=master)](https://zingzor.visualstudio.com/CloudFlare.Client/_build/latest?definitionId=1&branchName=master)
[![Azure DevOps tests](https://img.shields.io/azure-devops/tests/zingzor/CloudFlare.Client/1.svg)](https://zingzor.visualstudio.com/CloudFlare.Client/_build/latest?definitionId=1&branchName=master)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=CloudFlare.Client&metric=coverage)](https://sonarcloud.io/dashboard?id=CloudFlare.Client) 
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=CloudFlare.Client&metric=alert_status)](https://sonarcloud.io/dashboard?id=CloudFlare.Client) 
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=CloudFlare.Client&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=CloudFlare.Client)

> **_Info:_**  The library currently targets LTS .Net Core and .Net Standard platforms

## Usage

```csharp
    using var client = new CloudFlareClient("address@example.com", "globalApiKeyFromCF");

    var zones = await client.Zones.GetAsync(cancellationToken: ct);

    foreach (var zone in zones.Result)
    {
        var dnsRecords = await client.Zones.DnsRecords.GetAsync(zone.Id, cancellationToken: ct);
        foreach (var dnsRecord in dnsRecords.Result)
        {
            Console.WriteLine(dnsRecord.Name);
        }

        Console.WriteLine(zone.Name);
    }
```

For real example check out this dns updater project: [CloudFlare DNS Updater Service](https://github.com/zingz0r/CloudFlareDnsUpdater)

## Implemented functionality
Check the implemented functionality [wiki](../../wiki//Implemented-functionality) page.
