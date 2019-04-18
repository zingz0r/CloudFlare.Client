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

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.cloudflare.com/client/v4/")
            };

            _httpClient.DefaultRequestHeaders.Add("X-Auth-Email", emailAddress);
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Key", globalApiKey);
        }

        #endregion

        #region Zone

        public Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account)
        {
            return CreateZoneAsync(name, type, account, false);
        }

        public async Task<CloudFlareResult<Zone>> CreateZoneAsync(string name, ZoneType type, Account account, bool jumpStart)
        {
            try
            {
                PostZone postZone = new PostZone()
                {
                    Name = name,
                    Account = account,
                    Type = type,
                    JumpStart = jumpStart
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

        public async Task<CloudFlareResult<Zone>> EditZoneAsync(string zoneId, bool paused = false, IEnumerable<string> vanityNameServers = null, int? planId = null)
        {
            //curl - X PATCH "https://api.cloudflare.com/client/v4/zones/023e105f4ecef8ad9ca31a8372d0c353" \
            //-H "X-Auth-Email: user@example.com" \
            //-H "X-Auth-Key: c2547eb745079dac9320b638f5e225cf483cc5cfdda41" \
            //-H "Content-Type: application/json" \
            //--data '{"paused":false,"vanity_name_servers":["ns1.example.com","ns2.example.com"],"plan":{"id":"e592fd9519420ba7405e1307bff33214"}}'

            throw new NotImplementedException();
        }

        public async Task<CloudFlareResult<IEnumerable<Zone>>> GetZonesAsync(string name = "", ZoneStatus? status = null, int? page = null, int? perPage = null,
            OrderType? order = null, bool? match = null)
        {
            var parameterBuilder = new StringBuilder();
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Name, name);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Status, status);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Page, page);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.PerPage, perPage);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Order, order);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Match, match);

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

        #region DNS Records for a Zone

        public async Task<CloudFlareResult<DnsRecord>> CreateDnsRecordAsync(string zoneId, DnsRecordType type, string name, string content, int? ttl = null,
            int? priority = null, bool? proxied = null)
        {
            try
            {
                var newDnsRecord = new DnsRecord()
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

        public async Task<CloudFlareResult<IEnumerable<DnsRecord>>> GetDnsRecordsAsync(string zoneId, DnsRecordType? type = null, string name = "", string content = "",
            int? page = null, int? perPage = null, OrderType? order = null, bool? match = null)
        {
            var parameterBuilder = new StringBuilder();
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.DnsRecordType, type);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Name, name);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Content, content);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Page, page);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.PerPage, perPage);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Order, order);
            ParameterBuilderHelper.InsertValue(ref parameterBuilder, ApiParameter.Match, match);

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

        public async Task<CloudFlareResult<ImportResult>> ImportDnsRecordsAsync(string zoneId, FileInfo fileInfo, bool? proxied = null)
        {
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new StringContent(proxied.ToString()), ApiParameter.Proxied);
                form.Add(new ByteArrayContent(File.ReadAllBytes(fileInfo.FullName), 0, Convert.ToInt32(fileInfo.Length)), "file", "hello1.jpg");


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

        public async Task<CloudFlareResult<DnsRecord>> UpdateDnsRecordAsync(string zoneId, string identifier, DnsRecordType type,
            string name, string content, int? ttl = null, bool? proxied = null)
        {
            try
            {
                var updatedDnsRecord = new DnsRecord()
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
    }
}
