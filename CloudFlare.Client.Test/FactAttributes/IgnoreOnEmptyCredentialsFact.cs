using Xunit;

namespace CloudFlare.Client.Test.FactAttributes
{
    public sealed class IgnoreOnEmptyCredentialsFactAttribute : FactAttribute
    {
        public IgnoreOnEmptyCredentialsFactAttribute()
        {
            if (string.IsNullOrEmpty(Credentials.Authentication.Email) ||
                string.IsNullOrEmpty(Credentials.Authentication.ApiKey))
            {
                Skip = "Authentication needed for this test";
            }
        }
    }
}