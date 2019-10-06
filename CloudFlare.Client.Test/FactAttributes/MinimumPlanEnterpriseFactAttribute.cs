using System.Linq;
using CloudFlare.Client.Enumerators;
using Xunit;

namespace CloudFlare.Client.Test.FactAttributes
{
    public sealed class MinimumPlanEnterpriseFactAttribute : FactAttribute
    {
        public MinimumPlanEnterpriseFactAttribute()
        {
            var hasEnterpriseLevelAccount = false;
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var accounts = client.GetAccountsAsync().Result.Result;
                foreach (var account in accounts)
                {
                    var subscriptions = client.GetAccountSubscriptionsAsync(account.Id).Result.Result;
                    if (subscriptions.Any(subscription => subscription.RatePlan.Id == LegacyType.Enterprise))
                    {
                        hasEnterpriseLevelAccount = true;
                    }
                }
            }

            if (!hasEnterpriseLevelAccount)
            {
                Skip = "Minimum enterprise level account needed!";
            }
        }
    }
}