using System;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Contexts
{
    /// <summary>
    /// Connection
    /// </summary>
    public interface IConnection : IDisposable
    {
        /// <summary>
        /// GET request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <returns><see cref="CloudFlareResult{T}"/></returns>
        Task<CloudFlareResult<TResult>> GetAsync<TResult>(string requestUri, CancellationToken cancellationToken);

        /// <summary>
        /// DELETE request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <returns><see cref="CloudFlareResult{T}"/></returns>
        Task<CloudFlareResult<TResult>> DeleteAsync<TResult>(string requestUri, CancellationToken cancellationToken);
		
        /// <summary>
        /// DELETE request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="content">Request body content</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <returns><see cref="CloudFlareResult{T}"/></returns>
        Task<CloudFlareResult<TResult>> DeleteAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken);

        /// <summary>
        /// PATCH request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="content">PATCH content</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <returns><see cref="CloudFlareResult{T}"/></returns>
        Task<CloudFlareResult<TResult>> PatchAsync<TResult>(string requestUri, TResult content, CancellationToken cancellationToken);

        /// <summary>
        /// PATCH request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="content">PATCH content</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <typeparam name="TContent">Type of the PATCH content</typeparam>
        /// <returns><see cref="CloudFlareResult{T}"/></returns>
        Task<CloudFlareResult<TResult>> PatchAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken);

        /// <summary>
        /// POST request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="content">POST content</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <returns><see cref="CloudFlareResult{T}"/></returns>
        Task<CloudFlareResult<TResult>> PostAsync<TResult>(string requestUri, TResult content, CancellationToken cancellationToken);

        /// <summary>
        /// POST request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="content">POST content</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <typeparam name="TContent">Type of the content</typeparam>
        /// <returns><see cref="CloudFlareResult{T}"/></returns>
        Task<CloudFlareResult<TResult>> PostAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken);

        /// <summary>
        /// PUT request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="content">PUT content</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <returns><see cref="CloudFlareResult{T}"/></returns>
        Task<CloudFlareResult<TResult>> PutAsync<TResult>(string requestUri, TResult content, CancellationToken cancellationToken);

        /// <summary>
        /// PUT request
        /// </summary>
        /// <param name="requestUri">Request Uri</param>
        /// <param name="content">PUT content</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <typeparam name="TContent">Type of the content</typeparam>
        /// <returns><see cref="CloudFlareResult{T}"/></returns>
        Task<CloudFlareResult<TResult>> PutAsync<TResult, TContent>(string requestUri, TContent content, CancellationToken cancellationToken);
    }
}
