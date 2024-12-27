using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Authentication;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Exceptions;
using CloudFlare.Client.Extensions;
using CloudFlare.Client.Helpers;
using Newtonsoft.Json;

namespace CloudFlare.Client.Contexts;

internal abstract class Connection : IConnection
{
    private readonly JsonMediaTypeFormatter _formatter;
    private readonly JsonSerializerSettings _serializerSettings;

    protected Connection(IAuthentication authentication, ConnectionInfo connectionInfo)
    {
        _serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
        _formatter = new JsonMediaTypeFormatter { SerializerSettings = _serializerSettings };

        HttpClient = CreateHttpClient(authentication, connectionInfo);

        IsDisposed = false;
    }

    ~Connection() => Dispose(false);

    protected HttpClient HttpClient { get; }

    protected bool IsDisposed { get; private set; }

    public async Task<CloudFlareResult<TResult>> GetAsync<TResult>(string requestUri, CancellationToken cancellationToken)
    {
        var response = await HttpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
        return await response.GetCloudFlareResultAsync<TResult>().ConfigureAwait(false);
    }

    public async Task<CloudFlareResult<TResult>> DeleteAsync<TResult>(string requestUri, CancellationToken cancellationToken)
    {
        var response = await HttpClient.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
        return await response.GetCloudFlareResultAsync<TResult>().ConfigureAwait(false);
    }

    public async Task<CloudFlareResult<TResult>> DeleteAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken)
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, requestUri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(content, _serializerSettings), Encoding.UTF8, HttpContentTypesHelper.Json)
            };

            var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return await response.GetCloudFlareResultAsync<TResult>().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new PersistenceUnavailableException(ex);
        }
    }

    public async Task<CloudFlareResult<TResult>> PatchAsync<TResult>(string requestUri, TResult content, CancellationToken cancellationToken)
    {
        return await PatchAsync<TResult, TResult>(requestUri, content, cancellationToken);
    }

    public async Task<CloudFlareResult<TResult>> PatchAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken)
    {
        try
        {
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, requestUri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(content, _serializerSettings), Encoding.UTF8, HttpContentTypesHelper.Json)
            };

            var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return await response.GetCloudFlareResultAsync<TResult>().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new PersistenceUnavailableException(ex);
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task<CloudFlareResult<TResult>> PostAsync<TResult>(string requestUri, TResult content, CancellationToken cancellationToken)
    {
        return await PostAsync<TResult, TResult>(requestUri, content, cancellationToken);
    }

    public async Task<CloudFlareResult<TResult>> PostAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken)
    {
        var response = content is HttpContent httpContent
            ? await HttpClient.PostAsync(requestUri, httpContent, cancellationToken).ConfigureAwait(false)
            : await HttpClient.PostAsync(requestUri, content, _formatter, cancellationToken).ConfigureAwait(false);

        return await response.GetCloudFlareResultAsync<TResult>().ConfigureAwait(false);
    }

    public async Task<CloudFlareResult<TResult>> PutAsync<TResult>(string requestUri, TResult content, CancellationToken cancellationToken)
    {
        return await PutAsync<TResult, TResult>(requestUri, content, cancellationToken);
    }

    public async Task<CloudFlareResult<TResult>> PutAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken)
    {
        var response = await HttpClient.PutAsync(requestUri, content, _formatter, cancellationToken).ConfigureAwait(false);
        return await response.GetCloudFlareResultAsync<TResult>().ConfigureAwait(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (IsDisposed)
        {
            return;
        }

        if (disposing)
        {
            HttpClient?.CancelPendingRequests();
            HttpClient?.Dispose();
        }

        IsDisposed = true;
    }

    private static HttpClient CreateHttpClient(IAuthentication authentication, ConnectionInfo connectionInfo)
    {
        var client = new HttpClient(CreateHttpClientHandler(connectionInfo), true)
        {
            BaseAddress = connectionInfo.Address
        };

        var version = typeof(CloudFlareClient).Assembly.GetName().Version;
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(nameof(CloudFlareClient), version.ToString()));
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HttpContentTypesHelper.Json));
        client.DefaultRequestHeaders.ExpectContinue = connectionInfo.ExpectContinue;

        if (connectionInfo.Timeout.HasValue)
        {
            client.Timeout = connectionInfo.Timeout.Value;
        }

        authentication.AddToHeaders(client);

        return client;
    }

    private static HttpClientHandler CreateHttpClientHandler(ConnectionInfo connectionInfo)
    {
        try
        {
            return new HttpClientHandler { AllowAutoRedirect = connectionInfo.AllowAutoRedirect, UseProxy = connectionInfo.UseProxy, Proxy = connectionInfo.Proxy };
        }
        catch (PlatformNotSupportedException)
        {
            // UseProxy, Proxy is not supported on some platforms
            return new HttpClientHandler { AllowAutoRedirect = connectionInfo.AllowAutoRedirect };
        }
    }
}
