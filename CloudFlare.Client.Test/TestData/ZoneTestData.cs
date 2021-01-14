using System;
using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData
{
    public class ZoneTestData
    {
        public static List<Zone> Zones { get; set; } = new()
        {
            new Zone
            {
                Account = AccountTestData.Accounts.First(),
                ActivatedDate = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                DevelopmentMode = 0,
                Id = "023e105f4ecef8ad9ca31a8372d0c353",
                ModifiedDate = DateTime.UtcNow,
                Name = "tothnet.hu",
                NameServers = new List<string> { "jill.ns.cloudflare.com", "rick.ns.cloudflare.com" },
                OriginalDnsHost = null,
                OriginalNameServers = new List<string> { "jill.ns.cloudflare.com", "rick.ns.cloudflare.com" },
                OriginalRegistrar = null,
                Owner = new Owner
                {
                    Email = "info@tothnet.hu",
                    Id = "f266558jtf766bafe0580a4f0e81c19b",
                    Type = OwnerType.User
                },
                Paused = false,
                Permissions = new List<string>{
                    "#access:edit",
                    "#access:read",
                    "#analytics:read",
                    "#app:edit",
                    "#auditlogs:read",
                    "#billing:edit",
                    "#billing:read",
                    "#cache_purge:edit",
                    "#dns_records:edit",
                    "#dns_records:read",
                    "#lb:edit",
                    "#lb:read",
                    "#legal:edit",
                    "#legal:read",
                    "#logs:edit",
                    "#logs:read",
                    "#member:edit",
                    "#member:read",
                    "#organization:edit",
                    "#organization:read",
                    "#ssl:edit",
                    "#ssl:read",
                    "#stream:edit",
                    "#stream:read",
                    "#subscription:edit",
                    "#subscription:read",
                    "#teams:edit",
                    "#teams:read",
                    "#teams:report",
                    "#waf:edit",
                    "#waf:read",
                    "#webhooks:edit",
                    "#webhooks:read",
                    "#worker:edit",
                    "#worker:read",
                    "#zone:edit",
                    "#zone:read",
                    "#zone_settings:edit",
                    "#zone_settings:read"
                },
                Plan = new Plan
                {
                    Id = "0feeeeeeeeeeeeeeeeeeeeeeeeeeeeee",
                    CanSubscribe = true,
                    IsSubscribed = false,
                    LegacyId = LegacyType.Free,
                    Currency = "USD",
                    Price = 0,
                }
            }
        };
    }
}