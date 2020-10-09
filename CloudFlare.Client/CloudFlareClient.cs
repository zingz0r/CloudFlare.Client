using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Account;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Exceptions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;
using CloudFlare.Client.Extensions;
using Newtonsoft.Json;

namespace CloudFlare.Client
{
    public class CloudFlareClient : ICloudFlareClient, IDisposable
    {
        #region Fields

        private HttpClient _httpClient;
        private static string AuthenticationErrorMessage => "Authentication error!";

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="cloudFlareAuthentication">CloudFlareAuthentication that contains email address and api key</param>
        public CloudFlareClient(Authentication cloudFlareAuthentication)
        {
            Initialize(cloudFlareAuthentication.Email, cloudFlareAuthentication.ApiKey, cloudFlareAuthentication.ApiToken);
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <param name="apiKey">CloudFlare API Key</param>
        public CloudFlareClient(string emailAddress, string apiKey)
        {
            Initialize(emailAddress, apiKey, null);
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="apiToken">API token</param>
        public CloudFlareClient(string apiToken)
        {
            Initialize(null, null, apiToken);
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <param name="apiKey">CloudFlare API Key</param>
        /// <param name="apiToken">CloudFlare API token</param>
        private void Initialize(string emailAddress, string apiKey, string apiToken)
        {
            if ((string.IsNullOrEmpty(emailAddress)
                || string.IsNullOrEmpty(apiKey))
                && string.IsNullOrEmpty(apiToken))
            {
                throw new AuthenticationException("Empty credentials! You must use email address/apikey or only api token combination.");
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiParameter.Config.BaseUrl)
            };

            if (!string.IsNullOrEmpty(apiToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken);

                var testTheUserOnAuth = VerifyTokenAsync().GetAwaiter().GetResult();
                if (!testTheUserOnAuth.Success || testTheUserOnAuth.Errors.Any())
                {
                    throw new AuthenticationException(AuthenticationErrorMessage);
                }
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Add(ApiParameter.Config.AuthEmailHeader, emailAddress);
                _httpClient.DefaultRequestHeaders.Add(ApiParameter.Config.AuthKeyHeader, apiKey);

                var testTheUserOnAuth = GetUserDetailsAsync().GetAwaiter().GetResult();
                if (!testTheUserOnAuth.Success || testTheUserOnAuth.Errors.Any())
                {
                    throw new AuthenticationException(AuthenticationErrorMessage);
                }
            }
        }

        #endregion

        #region User

        #region EditUserAsync

        public async Task<CloudFlareResult<User>> EditUserAsync(User editedUser)
        {
            var correctUserProps = new User
            {
                FirstName = editedUser.FirstName,
                LastName = editedUser.LastName,
                Telephone = editedUser.Telephone,
                Country = editedUser.Country,
                Zipcode = editedUser.Zipcode
            };

            return await SendRequestAsync<User>(_httpClient.PatchAsync(
                $"{ApiParameter.Endpoints.User.Base}/", CreatePatchContent(correctUserProps))).ConfigureAwait(false);
        }


        #endregion

        #region GetUserDetailsAsync

        public async Task<CloudFlareResult<User>> GetUserDetailsAsync()
        {
            return await SendRequestAsync<User>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.User.Base}/")).ConfigureAwait(false);
        }

        #endregion

        #region VerifyTokenAsync

        /// <summary>
        /// Verify API token
        /// </summary>
        /// <returns></returns>
        public async Task<CloudFlareResult<VerifyToken>> VerifyTokenAsync()
        {
            return await SendRequestAsync<VerifyToken>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Tokens.Base}/{ApiParameter.Endpoints.Tokens.Verify}")).ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region User's Account Memberships

        #region DeleteMembershipAsync
        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> DeleteMembershipAsync(string membershipId)
        {
            return await SendRequestAsync<IEnumerable<UserMembership>>(_httpClient.DeleteAsync(
                $"{ApiParameter.Endpoints.Membership.Base}/{membershipId}")).ConfigureAwait(false);
        }

        #endregion

        #region GetMembershipsAsync

        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync()
        {
            return await GetMembershipsAsync(null, null, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status)
        {
            return await GetMembershipsAsync(status, null, null, null, null, null).ConfigureAwait(false);

        }

        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName)
        {
            return await GetMembershipsAsync(status, accountName, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page)
        {
            return await GetMembershipsAsync(status, accountName, page, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page, int? perPage)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page, int? perPage,
            MembershipOrder? membershipOrder)
        {
            return await GetMembershipsAsync(status, accountName, page, perPage, membershipOrder, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page, int? perPage,
            MembershipOrder? membershipOrder, OrderType? order)
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


            return await SendRequestAsync<IEnumerable<UserMembership>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Membership.Base}/?{parameterString}")).ConfigureAwait(false);
        }

        #endregion

        #region GetMembershipDetailsAsync

        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipDetailsAsync(string membershipId)
        {
            return await SendRequestAsync<IEnumerable<UserMembership>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Membership.Base}/?{membershipId}")).ConfigureAwait(false);
        }

        #endregion

        #region UpdateMembershipAsync

        public async Task<CloudFlareResult<IEnumerable<UserMembership>>> UpdateMembershipStatusAsync(string membershipId, SetMembershipStatus status)
        {
            var data = new Dictionary<string, SetMembershipStatus>
            {
                {ApiParameter.Filtering.Status, status}
            };

            return await SendRequestAsync<IEnumerable<UserMembership>>(_httpClient.PutAsJsonAsync(
                $"{ApiParameter.Endpoints.Membership.Base}/{membershipId}", data)).ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Accounts

        #region GetAccountsAsync

        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync()
        {
            return await GetAccountsAsync(null, null, null).ConfigureAwait(false);
        }


        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page)
        {
            return await GetAccountsAsync(page, null, null).ConfigureAwait(false);
        }


        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page, int? perPage)
        {
            return await GetAccountsAsync(page, perPage, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page, int? perPage, OrderType? order)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;


            return await SendRequestAsync<IEnumerable<Account>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/?{parameterString}")).ConfigureAwait(false);
        }

        #endregion

        #region GetAccountDetailsAsync

        public async Task<CloudFlareResult<IEnumerable<Account>>> GetAccountDetailsAsync(string accountId)
        {
            return await SendRequestAsync<IEnumerable<Account>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/?{accountId}")).ConfigureAwait(false);
        }

        #endregion

        #region UpdateAccount

        public async Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name)
        {
            return await UpdateAccountAsync(accountId, name, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name,
            AccountSettings settings)
        {
            var updatedAccount = new Account
            {
                Id = accountId,
                Name = name,
                Settings = settings
            };

            return await SendRequestAsync<Account>(_httpClient.PutAsJsonAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}", updatedAccount)).ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Account Members

        #region AddAccountMemberAsync

        public async Task<CloudFlareResult<AccountMember>> AddAccountMemberAsync(string accountId, string emailAddress, IEnumerable<AccountRole> roles)
        {
            var addAccountMember = new PostAccount
            {
                EmailAddress = emailAddress,
                Roles = roles,
                Status = AddMembershipStatus.Pending
            };

            return await SendRequestAsync<AccountMember>(_httpClient.PostAsJsonAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}", addAccountMember)).ConfigureAwait(false);
        }

        #endregion

        #region DeleteAccountMemberAsync

        public async Task<CloudFlareResult<AccountMember>> DeleteAccountMemberAsync(string accountId, string memberId)
        {
            return await SendRequestAsync<AccountMember>(_httpClient.DeleteAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}")).ConfigureAwait(false);
        }

        #endregion

        #region GetAccountMembersAsync

        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId)
        {
            return await GetAccountMembersAsync(accountId, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page)
        {
            return await GetAccountMembersAsync(accountId, page, null, null).ConfigureAwait(false);

        }

        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage)
        {
            return await GetAccountMembersAsync(accountId, page, perPage, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage,
            OrderType? order)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;

            return await SendRequestAsync<IEnumerable<AccountMember>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/?{parameterString}")).ConfigureAwait(false);
        }

        #endregion

        #region GetAccountMemberDetailsAsync

        public async Task<CloudFlareResult<AccountMember>> GetAccountMemberDetailsAsync(string accountId, string memberId)
        {
            return await SendRequestAsync<AccountMember>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}")).ConfigureAwait(false);
        }

        #endregion

        #region UpdateAccountMemberAsync

        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, null, null, null).ConfigureAwait(false);

        }

        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code, User user)
        {
            return await UpdateAccountMemberAsync(accountId, memberId, roles, code, user, null).ConfigureAwait(false);

        }

        public async Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code, User user, MembershipStatus? status)
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

            return await SendRequestAsync<AccountMember>(
                _httpClient.PutAsJsonAsync($"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}", updatedAccountMember))
                .ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Account Subscriptions

        #region GetAccountSubscriptionsAsync

        public async Task<CloudFlareResult<IEnumerable<AccountSubscription>>> GetAccountSubscriptionsAsync(string accountId)
        {
            return await SendRequestAsync<IEnumerable<AccountSubscription>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Subscriptions}")).ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Roles

        #region GetRolesAsync

        public async Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRolesAsync(string accountId)
        {
            return await SendRequestAsync<IEnumerable<AccountRole>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Roles}")).ConfigureAwait(false);
        }

        #endregion

        #region GetRoleDetailsAsync

        public async Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRoleDetailsAsync(string accountId, string roleId)
        {
            return await SendRequestAsync<IEnumerable<AccountRole>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Roles}")).ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Zone

        #region CreateZoneAsync

        public async Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account)
        {
            return await CreateZoneAsync(name, type, account, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account, bool? jumpStart)
        {
            var postZone = new PostZone
            {
                Name = name,
                Account = account,
                Type = type,
                JumpStart = jumpStart ?? false
            };

            return await SendRequestAsync<Zone>(_httpClient.PostAsJsonAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/", postZone)).ConfigureAwait(false);
        }

        #endregion

        #region DeleteZoneAsync

        public async Task<CloudFlareResult<Zone>> DeleteZoneAsync(string zoneId)
        {
            return await SendRequestAsync<Zone>(_httpClient.DeleteAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}")).ConfigureAwait(false);
        }

        #endregion

        #region EditZoneAsync

        public async Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId, PatchZone patchZone)
        {
            return await SendRequestAsync<Zone>(_httpClient.PatchAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", CreatePatchContent(patchZone))).ConfigureAwait(false);
        }

        #endregion

        #region GetZonesAsync

        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync()
        {
            return await GetZonesAsync(null, null, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name)
        {
            return await GetZonesAsync(name, null, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status)
        {
            return await GetZonesAsync(name, status, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page)
        {
            return await GetZonesAsync(name, status, page, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage)
        {
            return await GetZonesAsync(name, status, page, perPage, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage, OrderType? order)
        {
            return await GetZonesAsync(name, status, page, perPage, order, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage,
            OrderType? order, bool? match)
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

            return await SendRequestAsync<IEnumerable<Zone>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/?{parameterString}")).ConfigureAwait(false);
        }

        #endregion

        #region GetZoneDetailsAsync

        public async Task<CloudFlareResult<Zone>> GetZoneDetailsAsync(string zoneId)
        {
            return await SendRequestAsync<Zone>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}")).ConfigureAwait(false);
        }

        #endregion

        #region PurgeAllFilesAsync

        public async Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything)
        {
            var content = new Dictionary<string, bool> { { ApiParameter.Outgoing.PurgeEverything, purgeEverything } };

            return await SendRequestAsync<Zone>(_httpClient.PostAsJsonAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.PurgeCache}", content)).ConfigureAwait(false);
        }

        #endregion

        #region ZoneActivationCheckAsync

        public async Task<CloudFlareResult<Zone>> ZoneActivationCheckAsync(string zoneId)
        {
            return await SendRequestAsync<Zone>(_httpClient.PutAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.ActivationCheck}", null)).ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region DNS Records for a Zone

        #region CreateDnsRecordAsync

        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, null, null, null).ConfigureAwait(false);

        }

        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, null, null).ConfigureAwait(false);

        }

        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl, int? priority)
        {
            return await CreateDnsRecordAsync(zoneId, type, name, content, ttl, priority, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl,
            int? priority, bool? proxied)
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

            return await SendRequestAsync<DnsRecord>(_httpClient.PostAsJsonAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/", newDnsRecord)).ConfigureAwait(false);
        }

        #endregion

        #region DeleteDnsRecordAsync

        public async Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId, string identifier)
        {
            return await SendRequestAsync<DnsRecord>(_httpClient.DeleteAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}/")).ConfigureAwait(false);
        }

        #endregion

        #region ExportDnsRecordsAsync
        public async Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId)
        {
            return await SendRequestAsync<string>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Export}/"))
                .ConfigureAwait(false);
        }

        #endregion

        #region GetDnsRecordsAsync

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId)
        {
            return await GetDnsRecordsAsync(zoneId, null, null, null, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type)
        {
            return await GetDnsRecordsAsync(zoneId, type, null, null, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, null, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content, int? page)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, int? perPage)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, int? perPage,
            OrderType? order)
        {
            return await GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, order, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content,
            int? page, int? perPage, OrderType? order, bool? match)
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

            return await SendRequestAsync<IEnumerable<DnsRecord>>(
                _httpClient.GetAsync($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/?{parameterString}")).ConfigureAwait(false);
        }

        #endregion

        #region GetDnsRecordDetailsAsync

        public async Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId, string identifier)
        {
            return await SendRequestAsync<DnsRecord>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}")).ConfigureAwait(false);
        }

        #endregion

        #region ImportDnsRecordsAsync

        public async Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo)
        {
            return await ImportDnsRecordsAsync(zoneId, fileInfo, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, bool? proxied)
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

            return await SendRequestAsync<DnsImportResult>(_httpClient.PostAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Import}/", form))
                .ConfigureAwait(false);
        }

        #endregion

        #region UpdateDnsRecordAsync

        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name, string content)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name, string content, int? ttl)
        {
            return await UpdateDnsRecordAsync(zoneId, identifier, type, name, content, ttl, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type,
            string name, string content, int? ttl, bool? proxied)
        {
            var updatedDnsRecord = new DnsRecord
            {
                Content = content,
                Type = type,
                Name = name,
                Ttl = ttl ?? 1,
                Proxied = proxied
            };

            return await SendRequestAsync<DnsRecord>(_httpClient.PutAsJsonAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}/", updatedDnsRecord)).ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region Custom Hostname for a Zone

        #region CreateCustomHostnameAsync

        public async Task<CloudFlareResult<CustomHostname>> CreateCustomHostnameAsync(string zoneId, string hostname, CustomHostnameSsl ssl)
        {
            var postCustomHostname = new PostCustomHostname
            {
                Hostname = hostname,
                Ssl = ssl
            };

            return await SendRequestAsync<CustomHostname>(_httpClient.PostAsJsonAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}", postCustomHostname)).ConfigureAwait(false);
        }

        #endregion

        #region GetCustomHostnamesAsync

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId)
        {
            return await GetCustomHostnamesAsync(zoneId, null, null, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, null, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page, int? perPage)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page, int? perPage,
            CustomHostnameOrderType? type)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page, int? perPage,
            CustomHostnameOrderType? type, OrderType? order)
        {
            return await GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, order, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesAsync(string zoneId, string hostname, int? page, int? perPage,
            CustomHostnameOrderType? type, OrderType? order, bool? ssl)
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

            return await SendRequestAsync<IEnumerable<CustomHostname>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}?{parameterString}")).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, null, null, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, null, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, null, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, null, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, null, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type,
            OrderType? order)
        {
            return await GetCustomHostnamesByIdAsync(zoneId, customHostnameId, page, perPage, type, order, null).ConfigureAwait(false);
        }

        public async Task<CloudFlareResult<IEnumerable<CustomHostname>>> GetCustomHostnamesByIdAsync(string zoneId, string customHostnameId, int? page, int? perPage, CustomHostnameOrderType? type,
            OrderType? order, bool? ssl)
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

            return await SendRequestAsync<IEnumerable<CustomHostname>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}?{parameterString}"))
                .ConfigureAwait(false);
        }

        #endregion

        #region GetCustomHostnameDetailsAsync

        public async Task<CloudFlareResult<CustomHostname>> GetCustomHostnameDetailsAsync(string zoneId, string customHostnameId)
        {
            return await SendRequestAsync<CustomHostname>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}")).ConfigureAwait(false);
        }

        #endregion

        #region EditCustomHostnameAsync

        public async Task<CloudFlareResult<CustomHostname>> EditCustomHostnameAsync(string zoneId, string customHostnameId, PatchCustomHostname patchCustomHostname)
        {
            return await SendRequestAsync<CustomHostname>(_httpClient.PatchAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}", CreatePatchContent(patchCustomHostname))).ConfigureAwait(false);
        }

        #endregion

        #region DeleteCustomHostnameAsync

        public async Task<CloudFlareResult<CustomHostname>> DeleteCustomHostnameAsync(string zoneId, string customHostnameId)
        {
            return await SendRequestAsync<CustomHostname>(_httpClient.DeleteAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.CustomHostname.Base}/{customHostnameId}")).ConfigureAwait(false);
        }

        #endregion

        #endregion

        #region SendRequestAsync

        /// <summary>
        /// Sends the request async with HttpClient and parses response in the given type
        /// </summary>
        /// <typeparam name="T">Will parse response in to this type</typeparam>
        /// <param name="request">The request task. Don't await before this func.</param>
        /// <returns></returns>
        private static async Task<CloudFlareResult<T>> SendRequestAsync<T>(Task<HttpResponseMessage> request)
        {
            try
            {
                var response = await request.ConfigureAwait(false);
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);


                switch (response.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.Unauthorized:
                        var errorResult = JsonConvert.DeserializeObject<CloudFlareResult<object>>(content);
                        throw new AuthenticationException(string.Join(Environment.NewLine, errorResult.Errors.Select(x => x.Message)));
                    default:
                        return JsonConvert.DeserializeObject<CloudFlareResult<T>>(content);
                }
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }

        #endregion

        #region CreatePatchContent

        /// <summary>
        /// Creates StringContent which can be send with PatchAsync
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
            if (disposing)
            {
                _httpClient?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
