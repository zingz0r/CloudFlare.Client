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
                Skip = "Authentication needed for this test";
            }
        }
    }
}