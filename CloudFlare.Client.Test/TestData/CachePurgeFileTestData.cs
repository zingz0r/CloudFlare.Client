using System.Collections.Generic;
using CloudFlare.Client.Client.Zones;

namespace CloudFlare.Client.Test.TestData
{
    public static class CachePurgeFileTestData
    {
        public static List<CachePurgeFile> CachePurgeFiles { get; set; } = new()
        {
            new CachePurgeFile { Url = "https://example.com/" },
            new CachePurgeFile { Url = "https://example.com/my-page?q=apple" },
            new CachePurgeFile
            {
                Url = "https://example.com/my-page?q=apple",
                Headers = new Dictionary<string, string> { { "Origin", "https://example2.com" } }
            }
        };
    }
}
