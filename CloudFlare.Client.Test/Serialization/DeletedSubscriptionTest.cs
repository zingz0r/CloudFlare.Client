using System.Collections.Generic;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization
{
    public class DeletedSubscriptionTest
    {
        [Fact]
        public void TestSerialization()
        {
            var sut = new DeletedSubscription();

            JsonHelper.GetSerializedKeys(sut).Should().BeEquivalentTo(new SortedSet<string> { "subscription_id" });
        }
    }
}