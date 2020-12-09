using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Helpers;
using CloudFlare.Client.Models;
using Newtonsoft.Json;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient : ICloudFlareClient, IDisposable
    {
        private bool _disposed;

        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri(ApiParameter.Config.BaseUrl)
        };

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

        ~CloudFlareClient()
        {
            Dispose(false);
        }
        
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
            return await DeleteCustomHostnameAsync(zoneId, customHostnameId, default).ConfigureAwait(false);
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
