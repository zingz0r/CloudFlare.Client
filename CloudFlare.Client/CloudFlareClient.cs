using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.DnsRecord;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Zone;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Exceptions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudFlare.Client
{
    public class CloudFlareClient : ICloudFlareClient, IDisposable
    {
        #region Fields

        private readonly HttpClient _httpClient;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize CloudFlare Client
        /// </summary>
        /// <param name="emailAddress">Email address</param>
        /// <param name="globalApiKey">CloudFlare Global API Key</param>
        public CloudFlareClient(string emailAddress, string globalApiKey)
        {
            if (string.IsNullOrEmpty(emailAddress)
                || string.IsNullOrEmpty(globalApiKey))
            {
                throw new AuthenticationException();
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.cloudflare.com/client/v4/")
            };

            _httpClient.DefaultRequestHeaders.Add("X-Auth-Email", emailAddress);
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Key", globalApiKey);
        }

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

            return SendRequestAsync<CloudFlareResult<Zone>>(_httpClient.PostAsJsonAsync($"zones/", postZone));
        }

        #endregion

        #region DeleteZoneAsync

        public Task<CloudFlareResult<Zone>> DeleteZoneAsync(string zoneId)
        {
            return SendRequestAsync<CloudFlareResult<Zone>>(_httpClient.DeleteAsync($"zones/{zoneId}"));
        }

        #endregion

        #region EditZoneAsync

        public Task<CloudFlareResult<Zone>> EditZoneAsync<T>(string zoneId, string key, T newValue)
        {
            var jsonString = new JObject { [key] = JsonConvert.SerializeObject(newValue) };
            var content = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");

            return SendRequestAsync<CloudFlareResult<Zone>>(_httpClient.PatchAsync($"zones/{zoneId}", content));
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
                .InsertValue(ApiParameter.Name, name)
                .InsertValue(ApiParameter.Status, status)
                .InsertValue(ApiParameter.Page, page)
                .InsertValue(ApiParameter.PerPage, perPage)
                .InsertValue(ApiParameter.Order, order)
                .InsertValue(ApiParameter.Match, match);

            var parameterString = parameterBuilder.ParameterCollection;

            return SendRequestAsync<CloudFlareResult<IEnumerable<Zone>>>(_httpClient.GetAsync($"zones/?{parameterString}"));
        }

        #endregion

        #region GetZoneDetailsAsync

        public Task<CloudFlareResult<Zone>> GetZoneDetailsAsync(string zoneId)
        {
            return SendRequestAsync<CloudFlareResult<Zone>>(_httpClient.GetAsync($"zones/{zoneId}"));
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

            return SendRequestAsync<CloudFlareResult<DnsRecord>>(_httpClient.PostAsJsonAsync($"zones/{zoneId}/dns_records/", newDnsRecord));
        }

        #endregion

        #region DeleteDnsRecordAsync

        public Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId, string identifier)
        {
            return SendRequestAsync<CloudFlareResult<DnsRecord>>(_httpClient.DeleteAsync($"zones/{zoneId}/dns_records/{identifier}/"));
        }

        #endregion

        #region ExportDnsRecordsAsync

        public Task<string> ExportDnsRecordsAsync(string zoneId)
        {
            return SendRequestAsync<string>(_httpClient.GetAsync($"zones/{zoneId}/dns_records/export/"));
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
                .InsertValue(ApiParameter.DnsRecordType, type)
                .InsertValue(ApiParameter.Name, name)
                .InsertValue(ApiParameter.Content, content)
                .InsertValue(ApiParameter.Page, page)
                .InsertValue(ApiParameter.PerPage, perPage)
                .InsertValue(ApiParameter.Order, order)
                .InsertValue(ApiParameter.Match, match);

            var parameterString = parameterBuilder.ParameterCollection;

            return SendRequestAsync<CloudFlareResult<IEnumerable<DnsRecord>>>(_httpClient.GetAsync($"zones/{zoneId}/dns_records/?{parameterString}"));
        }

        #endregion

        #region GetDnsRecordDetailsAsync

        public Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId, string identifier)
        {
            return SendRequestAsync<CloudFlareResult<DnsRecord>>(_httpClient.GetAsync($"zones/{zoneId}/dns_records/{identifier}"));
        }

        #endregion

        #region ImportDnsRecordsAsync

        public Task<CloudFlareResult<ImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo)
        {
            return ImportDnsRecordsAsync(zoneId, fileInfo, null);
        }

        public Task<CloudFlareResult<ImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, bool? proxied)
        {
            var form = new MultipartFormDataContent
            {
                {new StringContent(proxied.ToString()), ApiParameter.Proxied},
                {
                    new ByteArrayContent(File.ReadAllBytes(fileInfo.FullName), 0,
                        Convert.ToInt32(fileInfo.Length)),
                    "file", "upload.txt"
                }
            };

            return SendRequestAsync<CloudFlareResult<ImportResult>>(_httpClient.PostAsync($"zones/{zoneId}/dns_records/import/", form));
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

            return SendRequestAsync<CloudFlareResult<DnsRecord>>(_httpClient.PutAsJsonAsync($"zones/{zoneId}/dns_records/{identifier}/", updatedDnsRecord));
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
        private static async Task<T> SendRequestAsync<T>(Task<HttpResponseMessage> request)
        {
            try
            {
                var response = await request.ConfigureAwait(false);
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<T>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
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
