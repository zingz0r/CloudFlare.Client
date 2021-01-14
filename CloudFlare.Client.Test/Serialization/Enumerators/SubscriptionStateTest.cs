using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators
{
    public class SubscriptionStateTest
    {
        [Fact]
        public void TestSerialization()
        {
            JsonHelper.GetSerializedEnums<SubscriptionState>().Should().BeEquivalentTo(new SortedSet<string>
            {
                "Trial", "Provisioned", "Paid", "AwaitingPayment", "Cancelled", "Failed", "Expired"
            });
        }
    }
}