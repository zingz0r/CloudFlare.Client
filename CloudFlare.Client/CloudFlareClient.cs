using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
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
    public class CloudFlareClient : ICloudFlareClient
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

        public async Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account, bool? jumpStart)
        {
            try
            {
                var postZone = new PostZone
                {
                    Name = name,
                    Account = account,
                    Type = type,
                    JumpStart = jumpStart ?? false
                };

                var response = await _httpClient.PostAsJsonAsync($"zones/", postZone);
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<Zone>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }

        #endregion

        #region DeleteZoneAsync

        public async Task<CloudFlareResult<Zone>> DeleteZoneAsync(string zoneId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"zones/{zoneId}");
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<Zone>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }

        #endregion

        #region EditZoneAsync

        public async Task<CloudFlareResult<Zone>> EditZoneAsync<T>(string zoneId, string key, T newValue)
        {
            var jsonString = new JObject {[key] = JsonConvert.SerializeObject(newValue)};
            var content = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");


            try
            {
                var response = await _httpClient.PatchAsync($"zones/{zoneId}", content);
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<Zone>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
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

        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name, ZoneStatus? status, int? page, int? perPage,
            OrderType? order, bool? match)
        {
            var parameterBuilder = new StringBuilder();
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.Name, name);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.Status, status);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.Page, page);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.PerPage, perPage);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.Order, order);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.Match, match);

            var parameterString = parameterBuilder.Length != 0 ? parameterBuilder.ToString() : "";

            try
            {
                var response = await _httpClient.GetAsync($"zones/{parameterString}");
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<IEnumerable<Zone>>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }

        #endregion

        #region GetZoneDetailsAsync

        public async Task<CloudFlareResult<Zone>> GetZoneDetailsAsync(string zoneId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"zones/{zoneId}");
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<Zone>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
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

        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl,
            int? priority, bool? proxied)
        {
            try
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

                var response = await _httpClient.PostAsJsonAsync($"zones/{zoneId}/dns_records/", newDnsRecord);
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<DnsRecord>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }

        #endregion

        #region DeleteDnsRecordAsync

        public async Task<CloudFlareResult<DnsRecord>> DeleteDnsRecordAsync(string zoneId, string identifier)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"zones/{zoneId}/dns_records/{identifier}/");
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<DnsRecord>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }

        #endregion

        #region ExportDnsRecordsAsync

        public async Task<string> ExportDnsRecordsAsync(string zoneId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"zones/{zoneId}/dns_records/export/");
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
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

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type, string name, string content,
            int? page, int? perPage, OrderType? order, bool? match)
        {
            var parameterBuilder = new StringBuilder();
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.DnsRecordType, type);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.Name, name);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.Content, content);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.Page, page);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.PerPage, perPage);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.Order, order);
            parameterBuilder = ParameterBuilderHelper.InsertValue(parameterBuilder, ApiParameter.Match, match);

            var parameterString = parameterBuilder.Length != 0 ? parameterBuilder.ToString() : "";

            try
            {
                var response = await _httpClient.GetAsync($"zones/{zoneId}/dns_records/{parameterString}");
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<IEnumerable<DnsRecord>>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }

        #endregion

        #region GetDnsRecordDetailsAsync

        public async Task<CloudFlareResult<DnsRecord>> GetDnsRecordDetailsAsync(string zoneId, string identifier)
        {
            try
            {
                var response = await _httpClient.GetAsync($"zones/{zoneId}/dns_records/{identifier}");
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<DnsRecord>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }

        #endregion

        #region ImportDnsRecordsAsync

        public Task<CloudFlareResult<ImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo)
        {
            return ImportDnsRecordsAsync(zoneId, fileInfo, null);
        }

        public async Task<CloudFlareResult<ImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, bool? proxied)
        {
            try
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


                var response = await _httpClient.PostAsync($"zones/{zoneId}/dns_records/import/", form);

                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<ImportResult>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
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

        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type,
            string name, string content, int? ttl, bool? proxied)
        {
            try
            {
                var updatedDnsRecord = new DnsRecord
                {
                    Content = content,
                    Type = type,
                    Name = name,
                    Ttl = ttl ?? 1,
                    Proxied = proxied
                };

                var response = await _httpClient.PutAsJsonAsync($"zones/{zoneId}/dns_records/{identifier}/", updatedDnsRecord);
                if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return await response.Content.ReadAsAsync<CloudFlareResult<DnsRecord>>();
                }

                throw new PersistenceUnavailableException("Service returned response: " + response.StatusCode);
            }
            catch (Exception ex)
            {
                throw new PersistenceUnavailableException(ex);

            }
        }

        #endregion

        #endregion

        #region Dispose
    
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        #endregion

    }
}
