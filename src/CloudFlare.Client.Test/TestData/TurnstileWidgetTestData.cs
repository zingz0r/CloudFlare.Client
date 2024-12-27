using System;
using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts.TurnstileWidgets;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData;

public static class TurnstileWidgetTestData
{
    public static List<TurnstileWidget> TurnstileWidgets { get; set; } = new()
    {
        new TurnstileWidget
        {
            Id = "0x4BVF00AAAABn0R22HWm-YUc",
            BotFightMode = true,
            ClearanceLevel = ClearanceLevel.JsChallenge,
            CreatedOn = new DateTime(2023, 1, 1),
            Domains = new List<string> { "example1.com" },
            Mode = WidgetMode.Invisible,
            ModifiedOn = new DateTime(2023, 1, 2),
            Name = "Example Widget 1",
            OffLabel = false,
            Region = Region.World,
            Secret = "0x4AAF00AAAABn0R22HWm098HVBjhdsYUc"
        },
        new TurnstileWidget
        {
            Id = "0x4AAF00AAAABn0R22HWm-YUc",
            BotFightMode = false,
            ClearanceLevel = ClearanceLevel.Managed,
            CreatedOn = new DateTime(2023, 2, 1),
            Domains = new List<string> { "example2.com" },
            Mode = WidgetMode.NonInteractive,
            ModifiedOn = new DateTime(2023, 2, 2),
            Name = "Example Widget 2",
            OffLabel = true,
            Region = Region.World,
            Secret = "0x4AAF00AAAABn0R22HWm098HVBjhdqDFa"
        }
    };
}