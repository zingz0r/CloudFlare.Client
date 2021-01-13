using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Memberships;
using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData
{
    public class AccountsMembershipTestData
    {
        public static List<Membership<User, Role>> Memberships { get; set; } = new()
        {
            new Membership<User, Role>
            {
                Id = "4536bcfad5faccb111b47003c79917fa",
                Code = "05dd05cce12bbed97c0d87cd78e89bc2fd41a6cee72f27f6fc84af2e45c0fac0",
                Entity = UserTestData.Users.First(),
                Roles = RoleTestData.Roles,
                Status = MembershipStatus.Accepted
            }
        };
    }
}