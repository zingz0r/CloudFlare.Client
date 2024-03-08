using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Display;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Client;

namespace CloudFlare.Client.Extensions;

/// <summary>
/// Extensions for <see cref="IGetApi{TDisplayOptions,TResult}"/> and <see cref="IGetApi{TFilter,TDisplayOptions,TResult}"/>.
/// </summary>
public static class GetExtensions
{
    /// <summary>
    /// Get all results from all the pages.
    /// </summary>
    /// <typeparam name="TDisplayOptions">Display options</typeparam>
    /// <typeparam name="TResult">Result type</typeparam>
    /// <param name="api">The api</param>
    /// <param name="displayOptions">The display options</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of all items</returns>
    public static Task<CloudFlareResult<IReadOnlyList<TResult>>> GetAllAsync<TDisplayOptions, TResult>(
        this IGetApi<TDisplayOptions, TResult> api,
        TDisplayOptions displayOptions = null,
        CancellationToken cancellationToken = default)
        where TDisplayOptions : UnOrderableDisplayOptions, new()
    {
        return GetAllAsync(api.GetAsync, displayOptions, cancellationToken);
    }

    /// <summary>
    /// Get all results from all the pages.
    /// </summary>
    /// <typeparam name="TFilter">Filtering options</typeparam>
    /// <typeparam name="TDisplayOptions">Display options</typeparam>
    /// <typeparam name="TResult">Result type</typeparam>
    /// <param name="api">The api</param>
    /// <param name="filter">The filter</param>
    /// <param name="displayOptions">The display options</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A list of all items</returns>
    public static Task<CloudFlareResult<IReadOnlyList<TResult>>> GetAllAsync<TFilter, TDisplayOptions, TResult>(
        this IGetApi<TFilter, TDisplayOptions, TResult> api,
        TFilter filter = null,
        TDisplayOptions displayOptions = null,
        CancellationToken cancellationToken = default)
        where TFilter : class
        where TDisplayOptions : UnOrderableDisplayOptions, new()
    {
        return GetAllAsync((options, token) => api.GetAsync(filter, options, token), displayOptions, cancellationToken);
    }

    private static async Task<CloudFlareResult<IReadOnlyList<TResult>>> GetAllAsync<TDisplayOptions, TResult>(
        Func<TDisplayOptions, CancellationToken, Task<CloudFlareResult<IReadOnlyList<TResult>>>> fetch,
        TDisplayOptions displayOptions = null,
        CancellationToken cancellationToken = default)
        where TDisplayOptions : UnOrderableDisplayOptions, new()
    {
        displayOptions ??= new TDisplayOptions();

        if (displayOptions.Page.HasValue && displayOptions.Page != 1)
        {
            throw new ArgumentException("Page should not be set", nameof(displayOptions));
        }

        var initialPage = displayOptions.Page;

        try
        {
            displayOptions.Page = 1;

            var firstPage = await fetch(displayOptions, cancellationToken).ConfigureAwait(false);

            if (!firstPage.Success || firstPage.ResultInfo.TotalPage == 1)
            {
                return firstPage;
            }

            var timing = new TimingInfo
            {
                StartDateTime = firstPage.Timing.StartDateTime,
                ProcessTime = firstPage.Timing.ProcessTime
            };

            var result = new List<TResult>(firstPage.ResultInfo.Count);
            result.AddRange(firstPage.Result);

            for (var i = 2; i <= firstPage.ResultInfo.TotalPage; i++)
            {
                displayOptions.Page = i;

                var page = await fetch(displayOptions, cancellationToken).ConfigureAwait(false);

                timing.ProcessTime += page.Timing.ProcessTime;
                timing.EndDateTime = page.Timing.EndDateTime;

                if (!page.Success)
                {
                    return new CloudFlareResult<IReadOnlyList<TResult>>(
                        result,
                        page.ResultInfo,
                        false,
                        page.Messages,
                        page.Errors,
                        timing);
                }

                result.AddRange(page.Result);
            }

            displayOptions.Page = initialPage;

            return new CloudFlareResult<IReadOnlyList<TResult>>(
                result,
                firstPage.ResultInfo,
                true,
                firstPage.Messages,
                firstPage.Errors,
                timing);
        }
        finally
        {
            // Reset the parameter to its original value
            displayOptions.Page = initialPage;
        }
    }
}
