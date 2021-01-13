using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Memberships;
using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData
{
    public class AccountsMembershipTestData
    {
        public static List<Membership<User, Role>> MembershipsData { get; set; } = new()
        {
            new Membership<User, Role>
            {
                Id = "4536bcfad5faccb111b47003c79917fa",
                Code = "05dd05cce12bbed97c0d87cd78e89bc2fd41a6cee72f27f6fc84af2e45c0fac0",
                Entity = UserTestData.UsersData.First(),
                Roles = new List<Role>
                {
                    new()
                    {
                        Id = "3536bcfad5faccb999b47003c79917fb",
                        Name = "Account Administrator",
                        Description = "Administrative access to the entire Account",
                        Permissions = new Dictionary<string, Permission>
                        {
                            { "analytics", new Permission{ Read = true, Write = true} },
                            { "billing", new Permission{ Read = true, Write = true} },
                            { "cache_purge", new Permission{ Read = true, Write = true} },
                            { "dns", new Permission{ Read = true, Write = true} },
                            { "dns_records", new Permission{ Read = true, Write = true} },
                            { "lb", new Permission{ Read = true, Write = true} },
                            { "logs", new Permission{ Read = true, Write = true} },
                            { "organization", new Permission{ Read = true, Write = true} },
                            { "ssl", new Permission{ Read = true, Write = true} },
                            { "waf", new Permission{ Read = true, Write = true} },
                            { "zones", new Permission{ Read = true, Write = true} },
                            { "zone_settings", new Permission{ Read = true, Write = true} }
                        }
                    }
                },
                Status = MembershipStatus.Accepted
            }
        };
    }
}