using System.Linq;
using CloudFlare.Client.Enumerators;
using Xunit;

namespace CloudFlare.Client.Test.Attributes
{
    public sealed class MinimumPlanEnterpriseFactAttribute : FactAttribute
    {
        public MinimumPlanEnterpriseFactAttribute()
        {
            var hasEnterpriseLevelAccount = false;
            using (var client = new CloudFlareClient(Credentials.Authentication))
            {
                var accounts = client.Accounts.GetAsync().Result.Result;
                foreach (var account in accounts)
                {
                    var subscriptions = client.Accounts.Subscriptions.GetAsync(account.Id).Result.Result;
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