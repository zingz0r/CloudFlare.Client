using System;
using CloudFlare.Client.Client.Accounts;
using CloudFlare.Client.Client.Users;
using CloudFlare.Client.Client.Zones;

namespace CloudFlare.Client
{
    public interface ICloudFlareClient : IDisposable
    {
        IAccounts Accounts { get; }
        IUsers Users { get; }
        IZones Zones { get; }
    }
}
