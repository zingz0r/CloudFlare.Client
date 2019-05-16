using System;
using CloudFlare.Client.Models;

namespace CloudFlare.Client.Test.Credentials
{
    public static class Credentials
    {
        private static string ApiKey => Environment.GetEnvironmentVariable("CloudFlare.ApiKey");

        private static string EmailAddress => Environment.GetEnvironmentVariable("CloudFlare.EmailAddress");

        public static Authentication Authentication => new Authentication(EmailAddress, ApiKey);
    }
}