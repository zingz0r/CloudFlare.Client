using Xunit;

namespace CloudFlare.Client.Test.TheoryAttributes
{

    public sealed class IgnoreOnEmptyCredentialsTheoryAttribute : TheoryAttribute
    {
        public IgnoreOnEmptyCredentialsTheoryAttribute()
        {
            if (!Credentials.Credentials.HasApiKeyAuthentication && !Credentials.Credentials.HasApiTokenAuthentication)
            {
                Skip = "Authentication needed for this test";
            }
        }
    }
}