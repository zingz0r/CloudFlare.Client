using System;
using System.Collections.Generic;
using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData
{
    public static class TokenTestData
    {
        public static List<VerifyToken> Tokens = new()
        {
            new VerifyToken
            {
                Id = "ed17574386854bf78a67040be0a770b0",
                ExpiresOn = DateTime.UtcNow.AddDays(3),
                NotBefore = DateTime.UtcNow.AddDays(-1),
                Status = VerifyTokenStatus.Active,
                IssuedOn = DateTime.UtcNow,
                ModifiedOn = DateTime.UtcNow,
                Name = "Test Token"
            }
        };
    }
}