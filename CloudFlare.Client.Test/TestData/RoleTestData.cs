using System.Collections.Generic;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Accounts.Roles;

namespace CloudFlare.Client.Test.TestData
{
    public class RoleTestData
    {
        public static List<Role> Roles { get; set; } = new()
        {
            new Role
            {
                Id = "3536bcfad5faccb999b47003c79917fb",
                Name = "Account Administrator",
                Description = "Administrative access to the entire Account",
                Permissions = new Dictionary<string, Permission>
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
                }
            }
        };
    }
}