using System;
using CloudFlare.Client.Interfaces;

namespace CloudFlare.Client
{
    public interface ICloudFlareClient : IDisposable
    {
        IAccounts Accounts { get; }
        IUsers Users { get; }
        IZones Zones { get; }
    }
}
