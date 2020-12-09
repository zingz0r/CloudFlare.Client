using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
        /// <inheritdoc />
        public async Task<CloudFlareResult<User>> EditUserAsync(User editedUser)
        {
            return await EditUserAsync(editedUser, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<User>> EditUserAsync(User editedUser, CancellationToken cancellationToken)
        {
            var correctUserProps = new User
            {
                FirstName = editedUser.FirstName,
                LastName = editedUser.LastName,
                Telephone = editedUser.Telephone,
                Country = editedUser.Country,
                Zipcode = editedUser.Zipcode
            };

            return await _httpClient.PatchAsync<User>(
                    $"{ApiParameter.Endpoints.User.Base}/", PatchContentHelper.Create(correctUserProps), cancellationToken)
                .ConfigureAwait(false);
        }
    }
}