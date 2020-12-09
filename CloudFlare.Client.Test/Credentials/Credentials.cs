using System;
using System.Security.Authentication;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Test.Credentials
{
    public static class Credentials
    {
        public static string ApiKey { get; }
        public static string ApiToken { get; }
        public static string EmailAddress { get; }

        public static bool HasApiKeyAuthentication => !string.IsNullOrEmpty(EmailAddress) && !string.IsNullOrEmpty(ApiKey);
        public static bool HasApiTokenAuthentication => !string.IsNullOrEmpty(ApiToken);

        public static IAuthentication Authentication
        {
            get
            {
                if (HasApiTokenAuthentication)
                {
                    return new ApiTokenAuthentication(ApiToken);
                }

                if (HasApiKeyAuthentication)
                {
                    return new ApiKeyAuthentication(EmailAddress, ApiKey);
                }

                throw new AuthenticationException("No authentication provided");
            }
        }

        static Credentials()
        {
            EmailAddress = Environment.GetEnvironmentVariable("EmailAddress", EnvironmentVariableTarget.User);
            ApiKey = Environment.GetEnvironmentVariable("ApiKey", EnvironmentVariableTarget.User);
            ApiToken = Environment.GetEnvironmentVariable("ApiToken", EnvironmentVariableTarget.User);
        }
    }
}