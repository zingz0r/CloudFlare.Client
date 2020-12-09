# CloudFlare.Client

[![Donate](https://img.shields.io/badge/donate-PayPal-blueviolet.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=zgmode%40gmail.com&currency_code=USD&source=url)
[![Nuget](https://img.shields.io/nuget/v/CloudFlare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)
[![Nuget](https://img.shields.io/nuget/dt/Cloudflare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)
[![Libraries.io](https://img.shields.io/librariesio/github/zingz0r/CloudFlare.Client.svg)](https://libraries.io/github/zingz0r/CloudFlare.Client)
[![GitHub issues](https://img.shields.io/github/issues-raw/zingz0r/Cloudflare.Client.svg)](https://github.com/zingz0r/CloudFlare.Client/issues)
[![Licence](https://img.shields.io/badge/license-CC%20BY--NC--ND%204.0-orange.svg)](https://creativecommons.org/licenses/by-nc-nd/4.0/legalcode.txt)

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/0ad1b06d9bbd4c849715223677667ddf)](https://www.codacy.com/app/zingz0r/CloudFlare.Client?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=zingz0r/CloudFlare.Client&amp;utm_campaign=Badge_Grade)
[![Build Status](https://zingzor.visualstudio.com/CloudFlare.Client/_apis/build/status/zingz0r.CloudFlare.Client?branchName=master)](https://zingzor.visualstudio.com/CloudFlare.Client/_build/latest?definitionId=1&branchName=master)
[![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/zingzor/CloudFlare.Client/1.svg)](https://zingzor.visualstudio.com/CloudFlare.Client/_build/latest?definitionId=1&branchName=master)
[![Azure DevOps tests](https://img.shields.io/azure-devops/tests/zingzor/CloudFlare.Client/1.svg)](https://zingzor.visualstudio.com/CloudFlare.Client/_build/latest?definitionId=1&branchName=master)

> **_Info:_**  The library currently targets LTS .Net Core and .Net Standard platforms

## Usage

```csharp
    using var client = new CloudFlareClient("address@example.com", "globalApiKeyFromCF");
    
    var zones = await client.GetZonesAsync();

    foreach (var zone in zones.Result)
    {
        var dnsRecords = await client.GetDnsRecordsAsync(zone.Id);
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
