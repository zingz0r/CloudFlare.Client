using CloudFlare.Client.Api.Authentication;

namespace CloudFlare.Client.Contexts;

internal class ApiConnection(IAuthentication authentication, ConnectionInfo connectionInfo)
    : Connection(authentication, connectionInfo);
