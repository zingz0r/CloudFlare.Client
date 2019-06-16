# CloudFlare.Client

[![Donate](https://img.shields.io/badge/donate-PayPal-blueviolet.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=zgmode%40gmail.com&currency_code=USD&source=url)
[![Nuget](https://img.shields.io/nuget/v/CloudFlare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)
[![Nuget](https://img.shields.io/nuget/dt/Cloudflare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)
![Libraries.io dependency status for GitHub repo](https://img.shields.io/librariesio/github/zingz0r/CloudFlare.Client.svg)
[![GitHub issues](https://libraries.io/github/zingz0r/CloudFlare.Client)](https://github.com/zingz0r/CloudFlare.Client/issues)
[![Licence](https://img.shields.io/badge/license-CC%20BY--NC--ND%204.0-orange.svg)](https://creativecommons.org/licenses/by-nc-nd/4.0/legalcode.txt)

[![Codacy grade](https://img.shields.io/codacy/grade/0ad1b06d9bbd4c849715223677667ddf.svg)](https://app.codacy.com/app/zingz0r/CloudFlare.Client/commits)
[![Build Status](https://zingzor.visualstudio.com/CloudFlare.Client/_apis/build/status/zingz0r.CloudFlare.Client?branchName=master)](https://zingzor.visualstudio.com/CloudFlare.Client/_build/latest?definitionId=1&branchName=master)
[![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/zingzor/CloudFlare.Client/1.svg)](https://zingzor.visualstudio.com/CloudFlare.Client/_build/latest?definitionId=1&branchName=master)
[![Azure DevOps tests](https://img.shields.io/azure-devops/tests/zingzor/CloudFlare.Client/1.svg)](https://zingzor.visualstudio.com/CloudFlare.Client/_build/latest?definitionId=1&branchName=master)

.NET client for communication with the CloudFlare service API.

> **_Info:_**  The library currently targets `.Net Core 2.1`, `.Net Core 2.2`, `.Net Core 3.0` and `.NET Standard 2.1` because of the missing functions in the older frameworks.
> For example coz of [`PatchAsync`](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.patchasync?view=netstandard-2.1) in HTTPClient.

## Installation

```bash
    PM> Install-Package CloudFlare.Client -Version 1.1.8
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

### Account Members

-   [x] List Members
-   [x] Add Member
-   [x] Member Details
-   [x] Update Member
-   [x] Remove Member

### Account Roles

-   [x] List Roles
-   [x] Role Details

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
