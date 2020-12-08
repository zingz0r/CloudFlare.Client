using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Account;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;
using Newtonsoft.Json;

namespace CloudFlare.Client
{
    public class CloudFlareClient : ICloudFlareClient, IDisposable
    {
        #region Fields

        private bool _disposed;

        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri(ApiParameter.Config.BaseUrl)
        };

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="authentication">Authentication which can be ApiKey and Token based</param>
        public CloudFlareClient(IAuthentication authentication)
        {
            authentication.AddToHeaders(_httpClient);
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <param name="apiKey">CloudFlare API Key</param>
        public CloudFlareClient(string emailAddress, string apiKey)
        {
            var apiKeyAuthentication = new ApiKeyAuthentication(emailAddress, apiKey);
            apiKeyAuthentication.AddToHeaders(_httpClient);
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="apiToken">Authentication with api token</param>
        public CloudFlareClient(string apiToken)
        {
            var apiTokenAuthentication = new ApiTokenAuthentication(apiToken);
            apiTokenAuthentication.AddToHeaders(_httpClient);
        }

        #endregion

        #region Destructors

        ~CloudFlareClient()
        {
            Dispose(false);
        }

        #endregion

        #region User

        #region EditUserAsync

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
                $"{ApiParameter.Endpoints.User.Base}/", CreatePatchContent(correctUserProps), cancellationToken)
                .ConfigureAwait(false);
        }


        #endregion

        #region GetUserDetailsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<User>> GetUserDetailsAsync()
        {
            return await GetUserDetailsAsync(default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<User>> GetUserDetailsAsync(CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<User>($"{ApiParameter.Endpoints.User.Base}/", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region VerifyTokenAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<VerifyToken>> VerifyTokenAsync()
        {
            return await VerifyTokenAsync(default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<VerifyToken>> VerifyTokenAsync(CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<VerifyToken>($"{ApiParameter.Endpoints.Tokens.Base}/{ApiParameter.Endpoints.Tokens.Verify}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region User's Account Memberships

        #region DeleteMembershipAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> DeleteMembershipAsync(string membershipId)
        {
            return await DeleteMembershipAsync(default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> DeleteMembershipAsync(string membershipId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.DeleteAsync<IEnumerable<UserMembership>>(
                $"{ApiParameter.Endpoints.Membership.Base}/{membershipId}", cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region GetMembershipsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync()
        {
            return await GetMembershipsAsync(null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status)
        {
            return await GetMembershipsAsync(status, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(status, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName)
        {
            return await GetMembershipsAsync(status, accountName, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(status, accountName, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page)
        {
            return await GetMembershipsAsync(status, accountName, page, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(status, accountName, page, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage, MembershipOrder? membershipOrder)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, membershipOrder, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, CancellationToken cancellationToken)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, membershipOrder, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, OrderType? order)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, membershipOrder, order, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status,
            string accountName, int? page, int? perPage, MembershipOrder? membershipOrder, OrderType? order, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Status, status)
                .InsertValue(ApiParameter.Filtering.AccountName, accountName)
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Order, membershipOrder)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;


            return await _httpClient.GetAsync<IEnumerable<UserMembership>>(
                $"{ApiParameter.Endpoints.Membership.Base}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetMembershipDetailsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipDetailsAsync(string membershipId)
        {
            return await GetMembershipDetailsAsync(membershipId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipDetailsAsync(string membershipId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<IEnumerable<UserMembership>>(
                $"{ApiParameter.Endpoints.Membership.Base}/?{membershipId}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region UpdateMembershipAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> UpdateMembershipStatusAsync(string membershipId,
            SetMembershipStatus status)
        {
            return await UpdateMembershipStatusAsync(membershipId, status, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> UpdateMembershipStatusAsync(string membershipId,
            SetMembershipStatus status, CancellationToken cancellationToken)
        {
            var data = new Dictionary<string, SetMembershipStatus>
            {
                {ApiParameter.Filtering.Status, status}
            };

            return await _httpClient.PutAsync<IEnumerable<UserMembership>, Dictionary<string, SetMembershipStatus>>($"{ApiParameter.Endpoints.Membership.Base}/{membershipId}", data, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Accounts

        #region GetAccountsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync()
        {
            return await GetAccountsAsync(null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(CancellationToken cancellationToken)
        {
            return await GetAccountsAsync(null, null, null, cancellationToken).ConfigureAwait(false);
        }


        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page)
        {
            return await GetAccountsAsync(page, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page,
            CancellationToken cancellationToken)
        {
            return await GetAccountsAsync(page, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page,
            int? perPage)
        {
            return await GetAccountsAsync(page, perPage, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page,
            int? perPage, CancellationToken cancellationToken)
        {
            return await GetAccountsAsync(page, perPage, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page,
            int? perPage, OrderType? order)
        {
            return await GetAccountsAsync(page, perPage, order, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page,
            int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;


            return await _httpClient.GetAsync<IEnumerable<Account>>(
                $"{ApiParameter.Endpoints.Account.Base}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetAccountDetailsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountDetailsAsync(string accountId)
        {
            return await GetAccountDetailsAsync(accountId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountDetailsAsync(string accountId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<IEnumerable<Account>>(
                $"{ApiParameter.Endpoints.Account.Base}/?{accountId}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region UpdateAccount

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId,
            string name)
        {
            return await UpdateAccountAsync(accountId, name, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId,
            string name, CancellationToken cancellationToken)
        {
            return await UpdateAccountAsync(accountId, name, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId,
            string name, AccountSettings settings)
        {
            return await UpdateAccountAsync(accountId, name, settings, default).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId,
            string name, AccountSettings settings, CancellationToken cancellationToken)
        {
            var updatedAccount = new Account
            {
                Id = accountId,
                Name = name,
                Settings = settings
            };

            return await _httpClient.PutAsync<Account, Account>(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}", updatedAccount, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Account Members

        #region AddAccountMemberAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> AddAccountMemberAsync(string accountId,
            string emailAddress, IEnumerable<AccountRole> roles)
        {
            return await AddAccountMemberAsync(accountId, emailAddress, roles, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> AddAccountMemberAsync(string accountId,
            string emailAddress, IEnumerable<AccountRole> roles, CancellationToken cancellationToken)
        {
            var addAccountMember = new PostAccount
            {
                EmailAddress = emailAddress,
                Roles = roles,
                Status = AddMembershipStatus.Pending
            };

            return await _httpClient.PostAsync<AccountMember, PostAccount>(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}", addAccountMember, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region DeleteAccountMemberAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> DeleteAccountMemberAsync(string accountId,
            string memberId)
        {
            return await DeleteAccountMemberAsync(accountId, memberId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> DeleteAccountMemberAsync(string accountId,
            string memberId, CancellationToken cancellationToken)
        {
            return await _httpClient.DeleteAsync<AccountMember>(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetAccountMembersAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId)
        {
            return await GetAccountMembersAsync(accountId, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId,
            CancellationToken cancellationToken)
        {
            return await GetAccountMembersAsync(accountId, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page)
        {
            return await GetAccountMembersAsync(accountId, page, null, null, default).ConfigureAwait(false);

        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page, CancellationToken cancellationToken)
        {
            return await GetAccountMembersAsync(accountId, page, null, null, cancellationToken).ConfigureAwait(false);

        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page, int? perPage)
        {
            return await GetAccountMembersAsync(accountId, page, perPage, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetAccountMembersAsync(accountId, page, perPage, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page, int? perPage, OrderType? order)
        {
            return await GetAccountMembersAsync(accountId, page, perPage, order, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId,
            int? page, int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;

            return await _httpClient.GetAsync<IEnumerable<AccountMember>>(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetAccountMemberDetailsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> GetAccountMemberDetailsAsync(string accountId,
            string memberId)
        {
            return await GetAccountMemberDetailsAsync(accountId, memberId, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> GetAccountMemberDetailsAsync(string accountId,
            string memberId, CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<AccountMember>(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region UpdateAccountMemberAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, CancellationToken cancellationToken)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code, CancellationToken cancellationToken)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code, User user)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, user, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code, User user, CancellationToken cancellationToken)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, user, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code, User user, MembershipStatus? status)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, user, status, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId,
            string memberId, IEnumerable<AccountRole> roles, string code, User user, MembershipStatus? status, CancellationToken cancellationToken)
        {
            var updatedAccountMember = new AccountMember
            {
                Code = code,
                User = user,
                Roles = roles,
            };

            if (status.HasValue)
            {
                updatedAccountMember.Status = status.Value;
            }

            return await _httpClient.PutAsync<AccountMember, AccountMember>($"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}",
                    updatedAccountMember, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Account Subscriptions

        #region GetAccountSubscriptionsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountSubscription>>> GetAccountSubscriptionsAsync(string accountId)
        {
            return await GetAccountSubscriptionsAsync(accountId, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountSubscription>>> GetAccountSubscriptionsAsync(string accountId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<IEnumerable<AccountSubscription>>(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Subscriptions}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Roles

        #region GetRolesAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRolesAsync(string accountId)
        {
            return await GetRolesAsync(accountId, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRolesAsync(string accountId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<IEnumerable<AccountRole>>(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Roles}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetRoleDetailsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountRole>> GetRoleDetailsAsync(string accountId,
            string roleId)
        {
            return await GetRoleDetailsAsync(accountId, roleId, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<AccountRole>> GetRoleDetailsAsync(string accountId,
            string roleId, CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<AccountRole>(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Roles}/{roleId}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Zone

        #region CreateZoneAsync

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

        #endregion

        #region DeleteZoneAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> DeleteZoneAsync(string zoneId)
        {
            return await DeleteZoneAsync(zoneId, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> DeleteZoneAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.DeleteAsync<Zone>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region EditZoneAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId,
            PatchZone patchZone)
        {
            return await EditZoneAsync(zoneId, patchZone, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId,
            PatchZone patchZone, CancellationToken cancellationToken)
        {
            return await _httpClient.PatchAsync<Zone>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", CreatePatchContent(patchZone), cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetZonesAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync()
        {
            return await GetZonesAsync(null, null, null, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(CancellationToken cancellationToken)
        {
            return await GetZonesAsync(null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name)
        {
            return await GetZonesAsync(name, null, null, null, null, null, default).ConfigureAwait(false);
        }
                
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            CancellationToken cancellationToken)
        {
            return await GetZonesAsync(name, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status)
        {
            return await GetZonesAsync(name, status, null, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, CancellationToken cancellationToken)
        {
            return await GetZonesAsync(name, status, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page)
        {
            return await GetZonesAsync(name, status, page, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, CancellationToken cancellationToken)
        {
            return await GetZonesAsync(name, status, page, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage)
        {
            return await GetZonesAsync(name, status, page, perPage, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetZonesAsync(name, status, page, perPage, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage, OrderType? order)
        {
            return await GetZonesAsync(name, status, page, perPage, order, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetZonesAsync(name, status, page, perPage, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage, OrderType? order, bool? match)
        {
            return await GetZonesAsync(name, status, page, perPage, order, match, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name,
            ZoneStatus? status, int? page, int? perPage, OrderType? order, bool? match, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Name, name)
                .InsertValue(ApiParameter.Filtering.Status, status)
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Order, order)
                .InsertValue(ApiParameter.Filtering.Match, match);

            var parameterString = parameterBuilder.ParameterCollection;

            return await _httpClient.GetAsync<IEnumerable<Zone>>(
                $"{ApiParameter.Endpoints.Zone.Base}/?{parameterString}", cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region GetZoneDetailsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> GetZoneDetailsAsync(string zoneId)
        {
            return await GetZoneDetailsAsync(zoneId, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> GetZoneDetailsAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<Zone>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region PurgeAllFilesAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId,
            bool purgeEverything)
        {
            return await PurgeAllFilesAsync(zoneId, purgeEverything, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId,
            bool purgeEverything, CancellationToken cancellationToken)
        {
            var content = new Dictionary<string, bool> { { ApiParameter.Outgoing.PurgeEverything, purgeEverything } };

            return await _httpClient.PostAsync<Zone, Dictionary<string, bool>>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.PurgeCache}", content, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region ZoneActivationCheckAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> ZoneActivationCheckAsync(string zoneId)
        {
            return await ZoneActivationCheckAsync(zoneId, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<Zone>> ZoneActivationCheckAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.PutAsync<Zone, object>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.ActivationCheck}", "", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region DNS Records for a Zone

        #region CreateDnsRecordAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, CancellationToken cancellationToken)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl, CancellationToken cancellationToken)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl, int? priority)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, priority, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl, int? priority, CancellationToken cancellationToken)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, priority, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl, int? priority, bool? proxied)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, priority, proxied, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId,
            DnsRecordType type, string name, string content, int? ttl, int? priority, bool? proxied, CancellationToken cancellationToken)
        {
            var newDnsRecord = new DnsRecord
            {
                Content = content,
                Type = type,
                Name = name,
                Ttl = ttl ?? 1,
                Priority = priority ?? 0,
                Proxied = proxied
            };

            return await _httpClient.PostAsync<DnsRecord, DnsRecord>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/", newDnsRecord, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region DeleteDnsRecordAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId,
            string identifier)
        {
            return await DeleteDnsRecordAsync(zoneId, identifier, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId,
            string identifier, CancellationToken cancellationToken)
        {
            return await _httpClient.DeleteAsync<DnsRecord>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}/", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region ExportDnsRecordsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId)
        {
            return await ExportDnsRecordsAsync(zoneId, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<string>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Export}/", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetDnsRecordsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId)
        {
            return await GetDnsRecordsAsync(zoneId, null, null, null, null, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, null, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type)
        {
            return await GetDnsRecordsAsync(zoneId, type, null, null, null, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, null, null, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, null, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, order, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order, bool? match)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, order, match, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId,
            DnsRecordType? type, string name, string content, int? page, int? perPage, OrderType? order, bool? match, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.DnsRecordType, type)
                .InsertValue(ApiParameter.Filtering.Name, name)
                .InsertValue(ApiParameter.Filtering.Content, content)
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Order, order)
                .InsertValue(ApiParameter.Filtering.Match, match);

            var parameterString = parameterBuilder.ParameterCollection;

            return await _httpClient.GetAsync<IEnumerable<DnsRecord>>($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetDnsRecordDetailsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId,
            string identifier)
        {
            return await GetDnsRecordDetailsAsync(zoneId, identifier, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId,
            string identifier, CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<DnsRecord>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region ImportDnsRecordsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId,
            FileInfo fileInfo)
        {
            return await ImportDnsRecordsAsync(zoneId, fileInfo, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId,
            FileInfo fileInfo, CancellationToken cancellationToken)
        {
            return await ImportDnsRecordsAsync(zoneId, fileInfo, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId,
            FileInfo fileInfo, bool? proxied)
        {
            return await ImportDnsRecordsAsync(zoneId, fileInfo, proxied, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId,
            FileInfo fileInfo, bool? proxied, CancellationToken cancellationToken)
        {
            var form = new MultipartFormDataContent
            {
                {new StringContent(proxied.ToString()), ApiParameter.Filtering.Proxied},
                {
                    new ByteArrayContent(File.ReadAllBytes(fileInfo.FullName), 0,
                        Convert.ToInt32(fileInfo.Length)),
                    "file", "upload.txt"
                }
            };

            return await _httpClient.PostAsync<DnsImportResult, MultipartFormDataContent>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Import}/", form, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region UpdateDnsRecordAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content, CancellationToken cancellationToken)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content, int? ttl)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, ttl, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content, int? ttl, CancellationToken cancellationToken)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, ttl, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content, int? ttl, bool? proxied)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, ttl, proxied, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId,
            string identifier, DnsRecordType type, string name, string content, int? ttl, bool? proxied, CancellationToken cancellationToken)
        {
            var updatedDnsRecord = new DnsRecord
            {
                Content = content,
                Type = type,
                Name = name,
                Ttl = ttl ?? 1,
                Proxied = proxied
            };

            return await _httpClient.PutAsync<DnsRecord, DnsRecord>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}/", updatedDnsRecord, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Custom Hostname for a Zone

        #region CreateCustomHostnameAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> CreateCustomHostnameAsync(string zoneId,
            string hostname, CustomHostnameSsl ssl)
        {
            return await CreateCustomHostnameAsync(zoneId, hostname, ssl, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> CreateCustomHostnameAsync(string zoneId,
            string hostname, CustomHostnameSsl ssl, CancellationToken cancellationToken)
        {
            var postCustomHostname = new PostCustomHostname
            {
                Hostname = hostname,
                Ssl = ssl
            };

            return await _httpClient.PostAsync<CustomHostname, PostCustomHostname>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}",
                postCustomHostname, cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetCustomHostnamesAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId)
        {
            return await GetCustomHostnamesAsync(zoneId, null, null, null, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, null, null, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, null, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, null, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, null, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, order, null, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, order, ssl, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId,
            string hostname, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Hostname, hostname)
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Order, type)
                .InsertValue(ApiParameter.Filtering.Direction, order)
                .InsertValue(ApiParameter.Filtering.Ssl, ssl ?? false ? 1 : 0);

            var parameterString = parameterBuilder.ParameterCollection;

            return await _httpClient.GetAsync<IEnumerable<CustomHostname>>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetCustomHostnamesByIdAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, null, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, null, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, null, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, null, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, null, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, null, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, null, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, null, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, null, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, order, null, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, CancellationToken cancellationToken)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, order, null, cancellationToken).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, order, ssl, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId,
            string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type, OrderType? order, bool? ssl, CancellationToken cancellationToken)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Id, customHostnameId)
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Order, type)
                .InsertValue(ApiParameter.Filtering.Direction, order)
                .InsertValue(ApiParameter.Filtering.Ssl, ssl ?? false ? 1 : 0);

            var parameterString = parameterBuilder.ParameterCollection;

            return await _httpClient.GetAsync<IEnumerable<CustomHostname>>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}?{parameterString}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region GetCustomHostnameDetailsAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> GetCustomHostnameDetailsAsync(string zoneId,
            string customHostnameId)
        {
            return await GetCustomHostnameDetailsAsync(zoneId, customHostnameId, default).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> GetCustomHostnameDetailsAsync(string zoneId,
            string customHostnameId, CancellationToken cancellationToken)
        {
            return await _httpClient.GetAsync<CustomHostname>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region EditCustomHostnameAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> EditCustomHostnameAsync(string zoneId,
            string customHostnameId, PatchCustomHostname patchCustomHostname)
        {
            return await EditCustomHostnameAsync(zoneId, customHostnameId, patchCustomHostname, default).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> EditCustomHostnameAsync(string zoneId,
            string customHostnameId, PatchCustomHostname patchCustomHostname, CancellationToken cancellationToken)
        {
            return await _httpClient.PatchAsync<CustomHostname>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}",
                CreatePatchContent(patchCustomHostname), cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region DeleteCustomHostnameAsync

        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> DeleteCustomHostnameAsync(string zoneId,
            string customHostnameId)
        {
            return await DeleteCustomHostnameAsync(zoneId, customHostnameId).ConfigureAwait(false);
        }
        
        /// <inheritdoc />
        public async Task<CloudFlareResult<CustomHostname>> DeleteCustomHostnameAsync(string zoneId,
            string customHostnameId, CancellationToken cancellationToken)
        {
            return await _httpClient.DeleteAsync<CustomHostname>(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}", cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region CreatePatchContent

        /// <summary>
        /// Creates StringContent which can be sent with PatchAsync
        /// </summary>
        /// <typeparam name="T">Type of the incoming value</typeparam>
        /// <param name="value">Content to convert to sendable object</param>
        /// <returns></returns>
        private static StringContent CreatePatchContent<T>(T value)
        {
            return new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");
        }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                _httpClient?.Dispose();
            }

            _disposed = true;
        }

        public void Dispose() // Implement IDisposable
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
