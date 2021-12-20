using System;
using System.Collections.Generic;
using CloudFlare.Client.Api.Users;

namespace CloudFlare.Client.Test.TestData
{
    public static class UserTestData
    {
        public static List<User> Users { get; set; } = new()
        {
            new User
            {

                Id = "7c5dae5552338874e5053f2534d2767a",
                FirstName = "John",
                LastName = "Doe",
                Country = "Hungary",
                CreatedOn = DateTime.UtcNow.AddDays(-1),
                Email = "info@tothnet.hu",
                ModifiedOn = DateTime.UtcNow,
                Suspended = false,
                Telephone = "+3616548798",
                TwoFactorAuthenticationEnabled = false
            }
        };
    }
}