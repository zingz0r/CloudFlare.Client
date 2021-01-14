using System;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Contexts
{
    public interface IConnection : IDisposable
    {
        Task<CloudFlareResult<TResult>> GetAsync<TResult>(string requestUri, CancellationToken cancellationToken);
        Task<CloudFlareResult<TResult>> DeleteAsync<TResult>(string requestUri, CancellationToken cancellationToken);
        Task<CloudFlareResult<TResult>> PatchAsync<TResult>(string requestUri, TResult content, CancellationToken cancellationToken);
        Task<CloudFlareResult<TResult>> PatchAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken);
        Task<CloudFlareResult<TResult>> PostAsync<TResult>(string requestUri, TResult content, CancellationToken cancellationToken);
        Task<CloudFlareResult<TResult>> PostAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken);
        Task<CloudFlareResult<TResult>> PutAsync<TResult>(string requestUri, TResult content, CancellationToken cancellationToken);
        Task<CloudFlareResult<TResult>> PutAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken);
    }
}
