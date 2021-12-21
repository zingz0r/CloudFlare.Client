using System;
using CloudFlare.Client.Client.Accounts;
using CloudFlare.Client.Client.Users;
using CloudFlare.Client.Client.Zones;

namespace CloudFlare.Client
{
    /// <summary>
    /// Interface for interacting with CloudFlare
    /// </summary>
    public interface ICloudFlareClient : IDisposable
    {
        /// <summary>
        /// Accounts
        /// </summary>
        /// <value>The implementation of the accounts interaction</value>
        IAccounts Accounts { get; }

        /// <summary>
        /// Users
        /// </summary>
        /// <value>The implementation of the users interaction</value>
        IUsers Users { get; }

        /// <summary>
        /// Zones
        /// </summary>
        /// <value>The implementation of the zones interaction</value>
        IZones Zones { get; }
    }
}
