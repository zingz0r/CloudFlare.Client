using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Users.Memberships;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData
{
    public static class UserMembershipTestsData
    {
        public static List<Membership> Memberships { get; set; } = new()
        {
            new Membership
            {
                Account = AccountTestData.Accounts.First(),
                Code = "05dd05cce12bbed97c0d87cd78e89bc2fd41a6cee72f27f6fc84af2e45c0fac0",
                Id = "4536bcfad5faccb111b47003c79917fa",
                Permissions = PermissionTestData.Permissions,
                Roles = new List<string> { "Account Administrator" },
                Status = MembershipStatus.Accepted
            }
        };
    }
}