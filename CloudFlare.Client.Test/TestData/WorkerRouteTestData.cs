using System.Collections.Generic;
using CloudFlare.Client.Api.Zones.WorkerRoute;

namespace CloudFlare.Client.Test.TestData
{
    public static class WorkerRouteTestData
    {
        public static List<WorkerRoute> WorkerRoutes { get; set; } = new()
        {
            new WorkerRoute
            {
                Pattern = "example.net/*",
                Script = "maintenance",
                Id = "635cd51af7194948821174ded7327331",
            }
        };
    }
}