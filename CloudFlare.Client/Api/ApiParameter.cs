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
            public static class Account
            {
                public static string Base => "accounts";
                public static string Members => "members";
                public static string Subscriptions => "subscriptions";
                public static string Roles => "roles";
            }

            public static class CustomHostname
            {
                public static string Base => "custom_hostnames";
            }

            public static class DnsRecord
            {
                public static string Base => "dns_records";
                public static string Export => "export";
                public static string Import => "import";
            }

            public static class Membership
            {
                public static string Base => "memberships";
            }

            public static class User
            {
                public static string Base => "user";
            }

            public static class Zone
            {
                public static string Base => "zones";
                public static string PurgeCache => "purge_cache";
                public static string ActivationCheck => "activation_check";
            }

            public static class Tokens {
                public static string Base => "user/tokens";
                public static string Verify => "verify";
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
            /// Hostname representation on CloudFlare
            /// </summary>
            public static string Hostname => "hostname";

            /// <summary>
            /// Identifier representation on CloudFlare
            /// </summary>
            public static string Id => "id";

            /// <summary>
            /// Match representation on CloudFlare
            /// </summary>
            public static string Match => "match";

            /// <summary>
            /// Name representation on CloudFlare
            /// </summary>
            public static string Name => "name";

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
            /// Proxied representation on CloudFlare
            /// </summary>
            public static string Proxied => "proxied";

            /// <summary>
            /// Ssl representation on CloudFlare
            /// </summary>
            public static string Ssl => "ssl";

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
