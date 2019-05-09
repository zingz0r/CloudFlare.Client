using CloudFlare.Client.Models;

namespace CloudFlare.Client.Test
{
    public static class Credentials
    {
        private static string ApiKey => "";

        private static string EmailAddress => "";

        public static Authentication Authentication => new Authentication(EmailAddress, ApiKey);
    }
}