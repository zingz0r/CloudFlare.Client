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
        public static string BaseUrl => "https://api.cloudflare.com/client/v4/";

        public static string AuthEmailHeader => "X-Auth-Email";
        public static string AuthKeyHeader => "X-Auth-Key";
    }
}