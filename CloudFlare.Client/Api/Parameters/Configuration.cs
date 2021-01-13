namespace CloudFlare.Client.Api.Parameters
{
    /// <summary>
    /// CloudFlare specific configuration strings
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Base CloudFlare api url
        /// </summary>
        public const string BaseUrl = "https://api.cloudflare.com/client/v4/";

        public const string AuthEmailHeader = "X-Auth-Email";
        public const string AuthKeyHeader = "X-Auth-Key";
    }
}