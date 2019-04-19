namespace CloudFlare.Client.Api
{
    public static class ApiParameter
    {
        /// <summary>
        /// CloudFlare specific configuration strings
        /// </summary>
        public static class Config
        {
            /// <summary>
            /// Base CloudFlare api url
            /// </summary>
            public static string BaseUrl => "https://api.cloudflare.com/client/v4/";

            public static string AuthEmailHeader => "X-Auth-Email";
            public static string AuthKeyHeader => "X-Auth-Key";
        }

        public static class Endpoints
        {
           // public static string  { get; set; }
        }

        /// <summary>
        /// Filtering parameter names on CloudFlare
        /// </summary>
        public static class Filtering
        {
            /// <summary>
            /// Name representation on CloudFlare
            /// </summary>
            public static string Name => "name";

            /// <summary>
            /// Content representation on CloudFlare
            /// </summary>
            public static string Content => "content";

            /// <summary>
            /// DnsRecordType representation on CloudFlare
            /// </summary>
            public static string DnsRecordType => "type";

            /// <summary>
            /// Proxied representation on CloudFlare
            /// </summary>
            public static string Proxied => "proxied";

            /// <summary>
            /// Ttl representation on CloudFlare
            /// </summary>
            public static string Ttl => "ttl";

            /// <summary>
            /// Match representation on CloudFlare
            /// </summary>
            public static string Match => "match";

            /// <summary>
            /// Order representation on CloudFlare
            /// </summary>
            public static string Order => "order";

            /// <summary>
            /// Page representation on CloudFlare
            /// </summary>
            public static string Page => "page";

            /// <summary>
            /// PerPage representation on CloudFlare
            /// </summary>
            public static string PerPage => "per_page";

            /// <summary>
            /// Status representation on CloudFlare
            /// </summary>
            public static string Status => "status";
        }

        /// <summary>
        /// Outgoing parameter names for CloudFlare
        /// </summary>
        public static class Outgoing
        {
            public static string PurgeEverything => "purge_everything";
        }

    }
}
