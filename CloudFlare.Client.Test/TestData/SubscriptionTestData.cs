using System;
using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData
{
    public static class SubscriptionTestData
    {
        public static List<Subscription> Subscriptions { get; set; } = new()
        {
            new Subscription
            {
                App = new App { InstallId = null },
                ComponentValues = new List<ComponentValue>
                {
                    new() {Name = ComponentValueType.PageRules, Default = 3, Price = 0, Value = 0}
                },
                Currency = "USD",
                CurrentPeriodStart = DateTime.UtcNow,
                Frequency = Frequency.Monthly,
                Id = Guid.NewGuid().ToString(),
                Price = 0,
                RatePlan = new RatePlan
                {
                    Id = LegacyType.Free,
                    Currency = "USD",
                    ExternallyManaged = false,
                    IsContract = false,
                    PublicName = "Test RatePlan",
                    Scope = RatePlanScope.Zone,
                    Sets = new List<string>()
                },
                State = SubscriptionState.Paid
            }
        };
    }
}