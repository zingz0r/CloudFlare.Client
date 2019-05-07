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
            public static string MembershipBase => "memberships";
            public static string UserBase => "user";
            public static string ZoneBase => "zones";
            public static string DnsRecordBase => "dns_records";

            public static class DnsRecord
            {
                public static string Export => "export";
                public static string Import => "import";
            }

            public static class Zone
            {
                public static string PurgeCache => "purge_cache";
                public static string ActivationCheck => "activation_check";
            }
        }

        /// <summary>
        /// Filtering parameter names on CloudFlare
        /// </summary>
        public static class Filtering
        {
            /// <summary>
            /// Account name representation on CloudFlare
            /// </summary>
            public static string AccountName => "account.name";

            /// <summary>
            /// Name representation on CloudFlare
            /// </summary>
            public static string Name => "name";

            /// <summary>
            /// Content representation on CloudFlare
            /// </summary>
            public static string Content => "content";

            /// <summary>
            /// Direction representation on CloudFlare
            /// </summary>
            public static string Direction => "direction";

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
