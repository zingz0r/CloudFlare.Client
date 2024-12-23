using System.Net.Http;
using System.Security.Authentication;

namespace CloudFlare.Client.Api.Authentication;

/// <summary>
/// For authenticating with API token
/// </summary>
public class ApiTokenAuthentication : IAuthentication
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiTokenAuthentication"/> class
    /// </summary>
    /// <param name="apiToken">Api Token</param>
    public ApiTokenAuthentication(string apiToken)
    {
        ApiToken = apiToken;

        if (string.IsNullOrEmpty(apiToken))
        {
            throw new AuthenticationException("Empty token! You must set the token.");
        }
    }

    /// <summary>
    /// CloudFlare API Token
    /// </summary>
    public string ApiToken { get; }

    /// <inheritdoc />
    public void AddToHeaders(HttpClient client)
    {
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiToken);
    }
}
