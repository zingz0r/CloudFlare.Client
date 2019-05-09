# CloudFlare.Client

[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=zgmode%40gmail.com&currency_code=USD&source=url)
[![Nuget](https://img.shields.io/nuget/v/CloudFlare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)
[![Nuget](https://img.shields.io/nuget/dt/Cloudflare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)
[![Codacy grade](https://img.shields.io/codacy/grade/0ad1b06d9bbd4c849715223677667ddf.svg)](#)
[![GitHub issues](https://img.shields.io/github/issues-raw/zingz0r/Cloudflare.Client.svg)](https://github.com/zingz0r/CloudFlare.Client/issues)
[![Licence](https://img.shields.io/badge/licanse-CC%20BY--NC--ND%204.0-yellowgreen.svg)](https://creativecommons.org/licenses/by-nc-nd/4.0/legalcode.txt)

.NET client for communication with the CloudFlare service API.

> **_Info:_**  The library currently targets `.Net Core 2.1`, `.Net Core 2.2`, `.Net Core 3.0` and `.NET Standard 2.1` because of the missing functions in the older frameworks.
> For example coz of [`PatchAsync`](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.patchasync?view=netstandard-2.1) in HTTPClient.

## Installation

```bash
    PM> Install-Package CloudFlare.Client -Version 1.1.7
```

## Usage

```csharp
    using (var client = new CloudFlareClient("address@example.com", "globalApiKeyFromCF"))
    {
        var zonesQueryResult = client.GetZonesAsync().Result;

        foreach (var zone in zonesQueryResult.Result)
        {
            var dnsRecordQueryResult = client.GetDnsRecordsAsync(zone.Id).Result;
            foreach (var dnsRecord in dnsRecordQueryResult.Result)
            {
                Console.WriteLine(dnsRecord.Name);
            }

            Console.WriteLine(zone.Name);
        }
    }
```

## Implemented functionality

### User

-   [x] User Details
-   [x] Edit User

### User's Account Memberships

-   [x] List Memberships
-   [x] Membership Details
-   [x] Update Membership
-   [x] Delete Membership

### Accounts

-   [x] List Accounts
-   [x] Account Details
-   [x] Update Account

### Zone

-   [x] List Zones
-   [x] Create Zone
-   [x] Zone Details
-   [x] Edit Zone
-   [x] Delete Zone
-   [x] Zone Activation Check
-   [x] Purge All Files
-   [ ] Purge Files by URL
-   [ ] Purge Files by Cache-Tags or Host  

### DNS Records for a Zone

-   [x] List DNS Records
-   [x] Create DNS Record
-   [x] DNS Record Details
-   [x] Update DNS Record
-   [x] Delete DNS Record
-   [x] Import DNS Records
-   [x] Export DNS Records
