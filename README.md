# CloudFlare.Client

[![Donate](https://img.shields.io/badge/donate-PayPal-blueviolet.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=zgmode%40gmail.com&currency_code=USD&source=url)
[![Nuget](https://img.shields.io/nuget/v/CloudFlare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)
[![Nuget](https://img.shields.io/nuget/dt/Cloudflare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)
[![Libraries.io](https://img.shields.io/librariesio/github/zingz0r/CloudFlare.Client.svg)](https://libraries.io/github/zingz0r/CloudFlare.Client)
[![GitHub issues](https://img.shields.io/github/issues-raw/zingz0r/Cloudflare.Client.svg)](https://github.com/zingz0r/CloudFlare.Client/issues)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

[![♻️ CI](https://github.com/zingz0r/CloudFlare.Client/actions/workflows/ci.yml/badge.svg?branch=master)](https://github.com/zingz0r/CloudFlare.Client/actions/workflows/ci.yml?query=branch%3Amaster)
[![♻️ CD](https://github.com/zingz0r/CloudFlare.Client/actions/workflows/cd.yml/badge.svg)](https://github.com/zingz0r/CloudFlare.Client/actions/workflows/cd.yml)

> **_Info:_**  The library currently targets the .Net Standard platforms

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
