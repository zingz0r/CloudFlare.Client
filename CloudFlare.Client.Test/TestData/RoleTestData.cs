using System.Collections.Generic;
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
                Permissions = PermissionTestData.Permissions
            }
        };
    }
}