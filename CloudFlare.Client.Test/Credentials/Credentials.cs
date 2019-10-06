using System;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Test.Credentials
{
    public static class Credentials
    {
        private static string ApiKey => "1f009bf93a142d2cd7ff8b4adcd137e6edc09"; //Environment.GetEnvironmentVariable("ApiKey", EnvironmentVariableTarget.Process);

        private static string ApiToken => Environment.GetEnvironmentVariable("ApiToken", EnvironmentVariableTarget.Process);

        private static string EmailAddress => "zgmode@gmail.com"; //Environment.GetEnvironmentVariable("EmailAddress", EnvironmentVariableTarget.Process);

        public static Authentication Authentication => new Authentication(EmailAddress, ApiKey, ApiToken);
    }
}