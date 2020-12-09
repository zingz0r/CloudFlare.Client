using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> CreateZoneAsync(string name,
            ZoneType type, Account account)
        {
            return await CreateZoneAsync(name, type, account, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> CreateZoneAsync(string name,
            ZoneType type, Account account, CancellationToken cancellationToken)
        {
            return await CreateZoneAsync(name, type, account, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> CreateZoneAsync(string name,
            ZoneType type, Account account, bool? jumpStart)
        {
            return await CreateZoneAsync(name, type, account, jumpStart, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> CreateZoneAsync(string name,
            ZoneType type, Account account, bool? jumpStart, CancellationToken cancellationToken)
        {
            var postZone = new PostZone
            {
                Name = name,
                Account = account,
                Type = type,
                JumpStart = jumpStart ?? false
            };

            return await _httpClient.PostAsync<Zone, PostZone>(
                $"{ApiParameter.Endpoints.Zone.Base}/", postZone, cancellationToken).ConfigureAwait(false);
        }
    }
}