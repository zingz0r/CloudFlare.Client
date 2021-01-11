using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Contexts
{
    public interface IConnection : IDisposable
    {
        Uri BaseAddress { get; }

        Task<CloudFlareResult<T>> GetAsync<T>(string requestUri, CancellationToken cancellationToken);
        Task<CloudFlareResult<T>> DeleteAsync<T>(string requestUri, CancellationToken cancellationToken);
        Task<CloudFlareResult<T>> PatchAsync<T>(string requestUri, HttpContent content, CancellationToken cancellationToken);
        Task<CloudFlareResult<TResult>> PostAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken);
        Task<CloudFlareResult<TResult>> PutAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken);
    }
}
