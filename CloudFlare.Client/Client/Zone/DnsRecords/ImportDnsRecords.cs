using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Extensions;

namespace CloudFlare.Client
{
    public partial class CloudFlareClient
    {
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

    }
}