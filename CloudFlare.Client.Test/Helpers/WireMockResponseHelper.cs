using System.Text.Json;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Test.TestData;

namespace CloudFlare.Client.Test.Helpers
{
    public static class WireMockResponseHelper
    {
        public static string CreateTestResponse<T>(T item)
        {
            return JsonSerializer.Serialize(new CloudFlareResult<T>(
                item,
                CommonTestData.ResultInfo,
                true,
                CommonTestData.ErrorDetails,
                CommonTestData.ApiErrors,
                CommonTestData.TimingInfo));
        }
    }
}