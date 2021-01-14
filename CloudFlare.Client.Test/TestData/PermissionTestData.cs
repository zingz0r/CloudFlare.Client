using System.Collections.Generic;
using CloudFlare.Client.Api;

namespace CloudFlare.Client.Test.TestData
{
    public static class PermissionTestData
    {
        public static Dictionary<string, Permission> Permissions { get; set; } = new Dictionary<string, Permission>
        {
            {"analytics", new Permission {Read = true, Write = true}},
            {"billing", new Permission {Read = true, Write = true}},
            {"cache_purge", new Permission {Read = true, Write = true}},
            {"dns", new Permission {Read = true, Write = true}},
            {"dns_records", new Permission {Read = true, Write = true}},
            {"lb", new Permission {Read = true, Write = true}},
            {"logs", new Permission {Read = true, Write = true}},
            {"organization", new Permission {Read = true, Write = true}},
            {"ssl", new Permission {Read = true, Write = true}},
            {"waf", new Permission {Read = true, Write = true}},
            {"zones", new Permission {Read = true, Write = true}},
            {"zone_settings", new Permission {Read = true, Write = true}}
        };
    }
}