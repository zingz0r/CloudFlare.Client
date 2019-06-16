using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Exceptions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;
using Newtonsoft.Json;

namespace CloudFlare.Client
{
    public class CloudFlareClient : ICloudFlareClient, IDisposable
    {
        #region Fields

        private HttpClient _httpClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="cloudFlareAuthentication">CloudFlareAuthentication that contains email address and api key</param>
        public CloudFlareClient(Authentication cloudFlareAuthentication)
        {
            Initialize(cloudFlareAuthentication.Email, cloudFlareAuthentication.ApiKey);
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <param name="apiKey">CloudFlare API Key</param>
        public CloudFlareClient(string emailAddress, string apiKey)
        {
            Initialize(emailAddress, apiKey);
        }

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <param name="apiKey">CloudFlare API Key</param>
        private void Initialize(string emailAddress, string apiKey)
        {
            if (string.IsNullOrEmpty(emailAddress)
                || string.IsNullOrEmpty(apiKey))
            {
                throw new AuthenticationException("Empty credentials!");
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiParameter.Config.BaseUrl)
            };

            _httpClient.DefaultRequestHeaders.Add(ApiParameter.Config.AuthEmailHeader, emailAddress);
            _httpClient.DefaultRequestHeaders.Add(ApiParameter.Config.AuthKeyHeader, apiKey);

            var testTheUserOnAuth = GetUserDetailsAsync().Result;
            if (!testTheUserOnAuth.Success || testTheUserOnAuth.Errors.Any())
            {
                throw new AuthenticationException("Authentication error!");
            }
        }

        #endregion

        #region User

        #region EditUserAsync

        public Task<CloudFlareResult<User>> EditUserAsync(User editedUser)
        {
            var correctUserProps = new User
            {
                FirstName = editedUser.FirstName,
                LastName = editedUser.LastName,
                Telephone = editedUser.Telephone,
                Country = editedUser.Country,
                Zipcode = editedUser.Zipcode
            };

            return SendRequestAsync<User>(_httpClient.PatchAsync(
                $"{ApiParameter.Endpoints.User.Base}/", CreatePatchContent(correctUserProps)));
        }


        #endregion

        #region GetUserDetailsAsync

        public Task<CloudFlareResult<User>> GetUserDetailsAsync()
        {
            return SendRequestAsync<User>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.User.Base}/"));
        }

        #endregion

        #endregion

        #region User's Account Memberships

        #region DeleteMembershipAsync
        public Task<CloudFlareResult<IEnumerable<UserMembership>>> DeleteMembershipAsync(string membershipId)
        {
            return SendRequestAsync<IEnumerable<UserMembership>>(_httpClient.DeleteAsync(
                $"{ApiParameter.Endpoints.Membership.Base}/{membershipId}"));
        }

        #endregion

        #region GetMembershipsAsync

        public Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync()
        {
            return GetMembershipsAsync(null, null, null, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status)
        {
            return GetMembershipsAsync(status, null, null, null, null, null);

        }

        public Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName)
        {
            return GetMembershipsAsync(status, accountName, null, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page)
        {
            return GetMembershipsAsync(status, accountName, page, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page, int? perPage)
        {
            return GetMembershipsAsync(status, accountName, page, perPage, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page, int? perPage,
            MembershipOrder? membershipOrder)
        {
            return GetMembershipsAsync(status, accountName, page, perPage, membershipOrder, null);
        }

        public Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipsAsync(MembershipStatus? status, string accountName, int? page, int? perPage,
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


            return SendRequestAsync<IEnumerable<UserMembership>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Membership.Base}/?{parameterString}"));
        }

        #endregion

        #region GetMembershipDetailsAsync

        public Task<CloudFlareResult<IEnumerable<UserMembership>>> GetMembershipDetailsAsync(string membershipId)
        {
            return SendRequestAsync<IEnumerable<UserMembership>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Membership.Base}/?{membershipId}"));
        }

        #endregion

        #region UpdateMembershipAsync

        public Task<CloudFlareResult<IEnumerable<UserMembership>>> UpdateMembershipStatusAsync(string membershipId, SetMembershipStatus status)
        {
            var data = new Dictionary<string, SetMembershipStatus>
            {
                {ApiParameter.Filtering.Status, status}
            };

            return SendRequestAsync<IEnumerable<UserMembership>>(_httpClient.PutAsJsonAsync(
                $"{ApiParameter.Endpoints.Membership.Base}/{membershipId}", data));
        }

        #endregion

        #endregion

        #region Accounts

        #region GetAccountsAsync

        public Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync()
        {
            return GetAccountsAsync(null, null, null);
        }


        public Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page)
        {
            return GetAccountsAsync(page, null, null);
        }


        public Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page, int? perPage)
        {
            return GetAccountsAsync(page, perPage, null);
        }

        public Task<CloudFlareResult<IEnumerable<Account>>> GetAccountsAsync(int? page, int? perPage, OrderType? order)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;


            return SendRequestAsync<IEnumerable<Account>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/?{parameterString}"));
        }

        #endregion

        #region GetAccountDetailsAsync

        public Task<CloudFlareResult<IEnumerable<Account>>> GetAccountDetailsAsync(string accountId)
        {
            return SendRequestAsync<IEnumerable<Account>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/?{accountId}"));
        }

        #endregion

        #region UpdateAccount

        public Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name)
        {
            return UpdateAccountAsync(accountId, name, null);
        }

        public Task<CloudFlareResult<Account>> UpdateAccountAsync(string accountId, string name,
            AccountSettings settings)
        {
            var updatedAccount = new Account
            {
                Id = accountId,
                Name = name,
                Settings = settings
            };

            return SendRequestAsync<Account>(_httpClient.PutAsJsonAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}", updatedAccount));
        }

        #endregion

        #endregion

        #region Account Members

        #region AddAccountMemberAsync

        public Task<CloudFlareResult<AccountMember>> AddAccountMemberAsync(string accountId, string emailAddress, IEnumerable<AccountRole> roles)
        {
            var addAccountMember = new PostAccount
            {
                EmailAddress = emailAddress,
                Roles = roles,
                Status = AddMembershipStatus.Pending
            };

            return SendRequestAsync<AccountMember>(_httpClient.PostAsJsonAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}", addAccountMember));
        }

        #endregion

        #region DeleteAccountMemberAsync

        public Task<CloudFlareResult<AccountMember>> DeleteAccountMemberAsync(string accountId, string memberId)
        {
            return SendRequestAsync<AccountMember>(_httpClient.DeleteAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}"));
        }

        #endregion

        #region GetAccountMembersAsync

        public Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId)
        {
            return GetAccountMembersAsync(accountId, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page)
        {
            return GetAccountMembersAsync(accountId, page, null, null);

        }

        public Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage)
        {
            return GetAccountMembersAsync(accountId, page, perPage, null);
        }

        public Task<CloudFlareResult<IEnumerable<AccountMember>>> GetAccountMembersAsync(string accountId, int? page, int? perPage,
            OrderType? order)
        {
            var parameterBuilder = new ParameterBuilderHelper();

            parameterBuilder
                .InsertValue(ApiParameter.Filtering.Page, page)
                .InsertValue(ApiParameter.Filtering.PerPage, perPage)
                .InsertValue(ApiParameter.Filtering.Direction, order);

            var parameterString = parameterBuilder.ParameterCollection;

            return SendRequestAsync<IEnumerable<AccountMember>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/?{parameterString}"));
        }

        #endregion

        #region GetAccountMemberDetailsAsync

        public Task<CloudFlareResult<AccountMember>> GetAccountMemberDetailsAsync(string accountId, string memberId)
        {
            return SendRequestAsync<AccountMember>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}"));
        }

        #endregion

        #region UpdateAccountMemberAsync

        public Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles)
        {
            return UpdateAccountMemberAsync(accountId, memberId, roles, null, null, null);

        }

        public Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code)
        {
            return UpdateAccountMemberAsync(accountId, memberId, roles, code, null, null);
        }

        public Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code, User user)
        {
            return UpdateAccountMemberAsync(accountId, memberId, roles, code, user, null);

        }

        public Task<CloudFlareResult<AccountMember>> UpdateAccountMemberAsync(string accountId, string memberId, IEnumerable<AccountRole> roles, string code, User user, MembershipStatus? status)
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

            return SendRequestAsync<AccountMember>(_httpClient.PutAsJsonAsync($"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Members}/{memberId}", updatedAccountMember));
        }

        #endregion

        #endregion

        #region Account Subscriptions

        #region GetAccountSubscriptionsAsync

        public Task<CloudFlareResult<IEnumerable<AccountSubscription>>> GetAccountSubscriptionsAsync(string accountId)
        {
            return SendRequestAsync<IEnumerable<AccountSubscription>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Subscriptions}"));
        }

        #endregion

        #endregion

        #region Roles

        #region GetRolesAsync

        public Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRolesAsync(string accountId)
        {
            return SendRequestAsync<IEnumerable<AccountRole>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Roles}"));
        }

        #endregion

        #region GetRoleDetailsAsync

        public Task<CloudFlareResult<IEnumerable<AccountRole>>> GetRoleDetailsAsync(string accountId, string roleId)
        {
            return SendRequestAsync<IEnumerable<AccountRole>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Account.Base}/{accountId}/{ApiParameter.Endpoints.Account.Roles}"));
        }

        #endregion

        #endregion

        #region Zone

        #region CreateZoneAsync

        public Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account)
        {
            return CreateZoneAsync(name, type, account, null);
        }

        public Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account, bool? jumpStart)
        {
            var postZone = new PostZone
            {
                Name = name,
                Account = account,
                Type = type,
                JumpStart = jumpStart ?? false
            };

            return SendRequestAsync<Zone>(_httpClient.PostAsJsonAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/", postZone));
        }

        #endregion

        #region DeleteZoneAsync

        public Task<CloudFlareResult<Zone>> DeleteZoneAsync(string zoneId)
        {
            return SendRequestAsync<Zone>(_httpClient.DeleteAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}"));
        }

        #endregion

        #region EditZoneAsync

        public Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId, PatchZone patchZone)
        {
            return SendRequestAsync<Zone>(_httpClient.PatchAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}", CreatePatchContent(patchZone)));
        }

        #endregion

        #region GetZonesAsync

        public Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync()
        {
            return GetZonesAsync(null, null, null, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name)
        {
            return GetZonesAsync(name, null, null, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status)
        {
            return GetZonesAsync(name, status, null, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page)
        {
            return GetZonesAsync(name, status, page, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage)
        {
            return GetZonesAsync(name, status, page, perPage, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage, OrderType? order)
        {
            return GetZonesAsync(name, status, page, perPage, order, null);
        }

        public Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage,
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

            return SendRequestAsync<IEnumerable<Zone>>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/?{parameterString}"));
        }

        #endregion

        #region GetZoneDetailsAsync

        public Task<CloudFlareResult<Zone>> GetZoneDetailsAsync(string zoneId)
        {
            return SendRequestAsync<Zone>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}"));
        }

        #endregion

        #region PurgeAllFilesAsync

        public Task<CloudFlareResult<Zone>> PurgeAllFilesAsync(string zoneId, bool purgeEverything)
        {
            var content = new NameValueCollection { { ApiParameter.Outgoing.PurgeEverything, purgeEverything.ToString() } };

            return SendRequestAsync<Zone>(_httpClient.PostAsJsonAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.PurgeCache}", content));
        }

        #endregion

        #region ZoneActivationCheckAsync

        public Task<CloudFlareResult<Zone>> ZoneActivationCheckAsync(string zoneId)
        {
            return SendRequestAsync<Zone>(_httpClient.PutAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.Zone.ActivationCheck}", null));
        }

        #endregion

        #endregion

        #region DNS Records for a Zone

        #region CreateDnsRecordAsync

        public Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content)
        {
            return CreateDnsRecordAsync(zoneId, type, name, content, null, null, null);

        }

        public Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl)
        {
            return CreateDnsRecordAsync(zoneId, type, name, content, ttl, null, null);

        }

        public Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl, int? priority)
        {
            return CreateDnsRecordAsync(zoneId, type, name, content, ttl, priority, null);
        }

        public Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl,
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

            return SendRequestAsync<DnsRecord>(_httpClient.PostAsJsonAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/", newDnsRecord));
        }

        #endregion

        #region DeleteDnsRecordAsync

        public Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId, string identifier)
        {
            return SendRequestAsync<DnsRecord>(_httpClient.DeleteAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}/"));
        }

        #endregion

        #region ExportDnsRecordsAsync
        public Task<CloudFlareResult<string>> ExportDnsRecordsAsync(string zoneId)
        {
            return SendRequestAsync<string>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Export}/"));
        }

        #endregion

        #region GetDnsRecordsAsync

        public Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId)
        {
            return GetDnsRecordsAsync(zoneId, null, null, null, null, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type)
        {
            return GetDnsRecordsAsync(zoneId, type, null, null, null, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name)
        {
            return GetDnsRecordsAsync(zoneId, type, name, null, null, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content)
        {
            return GetDnsRecordsAsync(zoneId, type, name, content, null, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content, int? page)
        {
            return GetDnsRecordsAsync(zoneId, type, name, content, page, null, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, int? perPage)
        {
            return GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, null, null);
        }

        public Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content, int? page, int? perPage,
            OrderType? order)
        {
            return GetDnsRecordsAsync(zoneId, type, name, content, page, perPage, order, null);
        }

        public Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content,
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

            return SendRequestAsync<IEnumerable<DnsRecord>>(
                _httpClient.GetAsync($"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/?{parameterString}"));
        }

        #endregion

        #region GetDnsRecordDetailsAsync

        public Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId, string identifier)
        {
            return SendRequestAsync<DnsRecord>(_httpClient.GetAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}"));
        }

        #endregion

        #region ImportDnsRecordsAsync

        public Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo)
        {
            return ImportDnsRecordsAsync(zoneId, fileInfo, null);
        }

        public Task<CloudFlareResult<DnsImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, bool? proxied)
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

            return SendRequestAsync<DnsImportResult>(_httpClient.PostAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{ApiParameter.Endpoints.DnsRecord.Import}/", form));
        }

        #endregion

        #region UpdateDnsRecordAsync

        public Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name, string content)
        {
            return UpdateDnsRecordAsync(zoneId, identifier, type, name, content, null, null);
        }

        public Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type, string name, string content, int? ttl)
        {
            return UpdateDnsRecordAsync(zoneId, identifier, type, name, content, ttl, null);
        }

        public Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type,
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

            return SendRequestAsync<DnsRecord>(_httpClient.PutAsJsonAsync(
                $"{ApiParameter.Endpoints.Zone.Base}/{zoneId}/{ApiParameter.Endpoints.DnsRecord.Base}/{identifier}/", updatedDnsRecord));
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
                var content = await response.Content.ReadAsAsync<CloudFlareResult<T>>();


                switch (response.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                    case HttpStatusCode.Unauthorized:
                        throw new AuthenticationException(string.Join(Environment.NewLine, content.Errors.Select(x => x.Message)));
                    default:
                        return content;
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
