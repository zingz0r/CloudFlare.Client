using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Test.TestData;
using Newtonsoft.Json;

namespace CloudFlare.Client.Test.Helpers;

public static class WireMockResponseHelper
{
    public static string CreateTestResponse<T>(T item)
    {
        return JsonConvert.SerializeObject(new CloudFlareResult<T>(
            item,
            CommonTestData.ResultInfo,
            true,
            CommonTestData.ErrorDetails,
            CommonTestData.ApiErrors,
            CommonTestData.TimingInfo));
    }
}
