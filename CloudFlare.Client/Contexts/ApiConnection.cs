using CloudFlare.Client.Api.Authentication;

namespace CloudFlare.Client.Contexts;

internal class ApiConnection : Connection
{
    public ApiConnection(IAuthentication authentication, ConnectionInfo connectionInfo)
        : base(authentication, connectionInfo)
    {
    }
}
