using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudFlare.Client.Extensions;

internal static class HttpResponseMessageExtensions
{
    internal static async Task<CloudFlareResult<T>> GetCloudFlareResultAsync<T>(this HttpResponseMessage response)
    {
        try
        {
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            switch (response.StatusCode)
            {
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.Unauthorized:
                    var errorResult = JsonConvert.DeserializeObject<CloudFlareResult<object>>(content);
                    throw new AuthenticationException(string.Join(Environment.NewLine, errorResult.Errors.Select(x => x.Message)));
                default:
                    if (content.IsValidJson())
                    {
                        return JsonConvert.DeserializeObject<CloudFlareResult<T>>(content);
                    }

                    if (typeof(T) != typeof(string))
                    {
                        throw new PersistenceUnavailableException("Unexpected result from CloudFlare");
                    }

                    dynamic cast = content.Replace("\\n", Environment.NewLine);
                    return new CloudFlareResult<T>((T)cast, new ResultInfo(), true, new List<ErrorDetails>(), new List<ApiError>(), new TimingInfo());
            }
        }
        catch (Exception ex)
        {
            if (ex is AuthenticationException)
            {
                throw;
            }

            throw new PersistenceUnavailableException(ex);
        }
    }

    private static bool IsValidJson(this string content)
    {
        try
        {
            JToken.Parse(content);
        }
        catch
        {
            return false;
        }

        return true;
    }
}
