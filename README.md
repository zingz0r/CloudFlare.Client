[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=zgmode%40gmail.com&currency_code=USD&source=url)
[![Nuget](https://img.shields.io/nuget/v/CloudFlare.Client.svg)](https://www.nuget.org/packages/CloudFlare.Client/)

# CloudFlare.Client
.NET client for communication with the Cloudflare service API.

## Install through nuget
    PM> Install-Package CloudFlare.Client -Version 1.0.0
    
## Implemented functionality
### Zone
- [x] List Zones
- [x] Create Zone
- [x] Zone Details
- [ ] Edit Zone
- [ ] Delete Zone
- [ ] Zone Activation Check
- [ ] Purge All Files
- [ ] Purge Files by URL
- [ ] Purge Files by Cache-Tags or Host

### DNS Records for a Zone
- [x] List DNS Records
- [x] Create DNS Record
- [x] DNS Record Details
- [x] Update DNS Record
- [x] Delete DNS Record
- [x] Import DNS Records
- [x] Export DNS Records

