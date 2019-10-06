using Xunit;

namespace CloudFlare.Client.Test.TheoryAttributes
{

    public sealed class IgnoreOnEmptyCredentialsTheoryAttribute : TheoryAttribute
    {
        public IgnoreOnEmptyCredentialsTheoryAttribute()
        {
            if (string.IsNullOrEmpty(Credentials.Credentials.Authentication.Email) ||
                string.IsNullOrEmpty(Credentials.Credentials.Authentication.ApiKey))
            {
                if (string.IsNullOrEmpty(Credentials.Credentials.Authentication.ApiToken))
                {
                    Skip = "Authentication needed for this test";
                }
            }
        }
    }
}