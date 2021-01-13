using CloudFlare.Client.Api.Authentication;
using Xunit;

namespace CloudFlare.Client.Test.Attributes
{
    public sealed class OnlyWithApiTokenAuthenticationFactAttribute : FactAttribute
    {
        public OnlyWithApiTokenAuthenticationFactAttribute()
        {
            if (Credentials.Credentials.Authentication.GetType() != typeof(ApiTokenAuthentication))
            {
                Skip = "Only available with api token authentication!";
            }
        }
    }
}