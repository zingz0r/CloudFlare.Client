using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public interface ICreateZone
    {
        /// <summary>
        /// Create a new zone
        /// </summary>
        /// <param name="name">The domain name</param>
        /// <param name="type">Zone type</param>
        /// <param name="account">Information about the account the zone belongs to</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account);

        /// <summary>
        /// Create a new zone
        /// </summary>
        /// <param name="name">The domain name</param>
        /// <param name="type">Zone type</param>
        /// <param name="account">Information about the account the zone belongs to</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account, CancellationToken cancellationToken);

        /// <summary>
        /// Create a new zone
        /// </summary>
        /// <param name="name">The domain name</param>
        /// <param name="type">Zone type</param>
        /// <param name="account">Information about the account the zone belongs to</param>
        /// <param name="jumpStart">Automatically attempt to fetch existing DNS records</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account, bool? jumpStart);

        /// <summary>
        /// Create a new zone
        /// </summary>
        /// <param name="name">The domain name</param>
        /// <param name="type">Zone type</param>
        /// <param name="account">Information about the account the zone belongs to</param>
        /// <param name="jumpStart">Automatically attempt to fetch existing DNS records</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account, bool? jumpStart, CancellationToken cancellationToken);
    }
}