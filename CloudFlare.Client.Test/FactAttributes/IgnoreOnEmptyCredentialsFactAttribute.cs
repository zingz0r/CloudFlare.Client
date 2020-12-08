using Xunit;

namespace CloudFlare.Client.Test.FactAttributes
{
    public sealed class IgnoreOnEmptyCredentialsFactAttribute : FactAttribute
    {
        public IgnoreOnEmptyCredentialsFactAttribute()
        {
            if ((string.IsNullOrEmpty(Credentials.Credentials.EmailAddress) ||
                string.IsNullOrEmpty(Credentials.Credentials.ApiKey))
                && string.IsNullOrEmpty(Credentials.Credentials.ApiToken))
            {
                Skip = "Authentication needed for this test";
            }
        }
    }
}