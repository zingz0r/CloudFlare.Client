using CloudFlare.Client.Interfaces;

namespace CloudFlare.Client.Contexts
{
    public class ApiConnection : Connection
    {
        public ApiConnection(IAuthentication authentication) : base(authentication)
        {

        }
    }
}
