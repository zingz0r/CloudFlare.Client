using System.Collections.Generic;
using CloudFlare.Client.Api.Result;

namespace CloudFlare.Client.Test.TestData;

public static class CommonTestData
{
    public static ResultInfo ResultInfo { get; } = new();
    public static TimingInfo TimingInfo { get; } = new();
    public static IReadOnlyList<ErrorDetails> ErrorDetails { get; } = new List<ErrorDetails>();
    public static IReadOnlyList<ApiError> ApiErrors { get; } = new List<ApiError>();
}
