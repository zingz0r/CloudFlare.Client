using System;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Contexts;

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
    Task<CloudFlareResult<TResult>> GetAsync<TResult>(RelativeUri requestUri, CancellationToken cancellationToken);

    /// <summary>
    /// DELETE request
    /// </summary>
    /// <param name="requestUri">Request Uri</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="TResult">Type of the result</typeparam>
    /// <returns><see cref="CloudFlareResult{T}"/></returns>
    Task<CloudFlareResult<TResult>> DeleteAsync<TResult>(RelativeUri requestUri, CancellationToken cancellationToken);

    /// <summary>
    /// DELETE request
    /// </summary>
    /// <param name="requestUri">Request Uri</param>
    /// <param name="content">Request body content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="TResult">Type of the result</typeparam>
    /// <typeparam name="TContent">Type of the body content</typeparam>
    /// <returns><see cref="CloudFlareResult{T}"/></returns>
    Task<CloudFlareResult<TResult>> DeleteAsync<TResult, TContent>(RelativeUri requestUri, TContent content, CancellationToken cancellationToken);

    /// <summary>
    /// PATCH request
    /// </summary>
    /// <param name="requestUri">Request Uri</param>
    /// <param name="content">PATCH content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="TResult">Type of the result</typeparam>
    /// <returns><see cref="CloudFlareResult{T}"/></returns>
    Task<CloudFlareResult<TResult>> PatchAsync<TResult>(RelativeUri requestUri, TResult content, CancellationToken cancellationToken);

    /// <summary>
    /// PATCH request
    /// </summary>
    /// <param name="requestUri">Request Uri</param>
    /// <param name="content">PATCH content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="TResult">Type of the result</typeparam>
    /// <typeparam name="TContent">Type of the PATCH content</typeparam>
    /// <returns><see cref="CloudFlareResult{T}"/></returns>
    Task<CloudFlareResult<TResult>> PatchAsync<TResult, TContent>(RelativeUri requestUri, TContent content, CancellationToken cancellationToken);

    /// <summary>
    /// POST request
    /// </summary>
    /// <param name="requestUri">Request Uri</param>
    /// <param name="content">POST content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="TResult">Type of the result</typeparam>
    /// <returns><see cref="CloudFlareResult{T}"/></returns>
    Task<CloudFlareResult<TResult>> PostAsync<TResult>(RelativeUri requestUri, TResult content, CancellationToken cancellationToken);

    /// <summary>
    /// POST request
    /// </summary>
    /// <param name="requestUri">Request Uri</param>
    /// <param name="content">POST content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="TResult">Type of the result</typeparam>
    /// <typeparam name="TContent">Type of the content</typeparam>
    /// <returns><see cref="CloudFlareResult{T}"/></returns>
    Task<CloudFlareResult<TResult>> PostAsync<TResult, TContent>(RelativeUri requestUri, TContent content, CancellationToken cancellationToken);

    /// <summary>
    /// PUT request
    /// </summary>
    /// <param name="requestUri">Request Uri</param>
    /// <param name="content">PUT content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="TResult">Type of the result</typeparam>
    /// <returns><see cref="CloudFlareResult{T}"/></returns>
    Task<CloudFlareResult<TResult>> PutAsync<TResult>(RelativeUri requestUri, TResult content, CancellationToken cancellationToken);

    /// <summary>
    /// PUT request
    /// </summary>
    /// <param name="requestUri">Request Uri</param>
    /// <param name="content">PUT content</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <typeparam name="TResult">Type of the result</typeparam>
    /// <typeparam name="TContent">Type of the content</typeparam>
    /// <returns><see cref="CloudFlareResult{T}"/></returns>
    Task<CloudFlareResult<TResult>> PutAsync<TResult, TContent>(RelativeUri requestUri, TContent content, CancellationToken cancellationToken);
}
