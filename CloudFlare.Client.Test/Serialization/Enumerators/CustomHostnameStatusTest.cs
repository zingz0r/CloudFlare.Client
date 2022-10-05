using System.Collections.Generic;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Test.Helpers;
using FluentAssertions;
using Xunit;

namespace CloudFlare.Client.Test.Serialization.Enumerators
{
    public class CustomHostnameStatusTest
    {
        [Fact]
        public void TestSerialization()
        {
            JsonHelper.GetSerializedEnums<CustomHostnameStatus>().Should().BeEquivalentTo(new SortedSet<string>
            {
                "active", "active_redeploying", "blocked", "deleted", "moved", "pending", "pending_blocked", "pending_deletion", "pending_migration", "pending_provisioned", "provisioned", "test_active", "test_active_apex", "test_blocked", "test_failed", "test_pending"
            });
        }
    }
}