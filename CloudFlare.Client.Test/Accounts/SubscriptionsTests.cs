using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Accounts
{
    public class SubscriptionsTests
    {
        [Fact(Skip = "Would cause new subscription")]
        public async Task TestAddAccountSubscriptionsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync();
            var addSubscription = await client.Accounts.Subscriptions.AddAsync(accounts.Result.First().Id,
                new AccountSubscription
                {
                    App = new App
                    {
                        InstallId = null,
                    },
                    ComponentValues = new List<ComponentValue>
                    {
                        new()
                        {
                            Name = ComponentValueType.PageRules,
                            Default = 3,
                            Price = 0,
                            Value = 0
                        }
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
                });

            addSubscription.Should().NotBeNull();
            addSubscription.Success.Should().BeTrue();
            addSubscription.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetAccountSubscriptionsAsync()
        {
            using var client = new CloudFlareClient(Credentials.Credentials.Authentication);
            var accounts = await client.Accounts.GetAsync();
            var subscriptions = await client.Accounts.Subscriptions.GetAsync(accounts.Result.First().Id);

            subscriptions.Should().NotBeNull();
            subscriptions.Success.Should().BeTrue();
            subscriptions.Errors?.Should().BeEmpty();
        }
    }
}
