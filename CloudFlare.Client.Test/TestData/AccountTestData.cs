using System;
using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData
{
    public class AccountTestData
    {
        public static ResultInfo ResultInfo { get; } = new();
        public static TimingInfo TimingInfo { get; } = new();
        public static IReadOnlyList<ErrorDetails> ErrorDetails { get; } = new List<ErrorDetails>();
        public static IReadOnlyList<ApiError> ApiErrors { get; } = new List<ApiError>();

        public static List<Account> AccountsData { get; set; } = new()
        {
            new Account
            {
                CreatedOn = DateTime.UtcNow,
                Id = "9018a5658j8e64153adb7aa01sd619fc",
                Name = "John Doe",
                Type = AccountType.Standard,
                LegacyFlags =
                    new LegacyFlags
                    {
                        EnterpriseZoneQuota = new EnterpriseZoneQuota { Available = 0, Current = 0, Maximum = 0 }
                    },
                Settings = new AdditionalAccountSettings
                {
                    EnforceTwoFactorAuthentication = false,
                    AccessApprovalExpiry = null
                }
            }
        };
    }
}