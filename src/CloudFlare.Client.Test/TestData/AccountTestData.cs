﻿using System;
using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData;

public static class AccountTestData
{
    public static List<Account> Accounts { get; set; } = new()
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
        },
        new Account
        {
            CreatedOn = DateTime.UtcNow,
            Id = "9018a5658j8e64153adb7aa01sd619fd",
            Name = "Harry Potter",
            Type = AccountType.Enterprise,
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
