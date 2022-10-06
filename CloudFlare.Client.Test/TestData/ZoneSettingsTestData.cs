using System;
using System.Collections.Generic;
using System.Text;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Test.TestData
{
    public static class ZoneSettingsTestData
    {
        public static List<FeatureStatus> AlwaysUseHttpsValues { get; set; } = new()
        {
            FeatureStatus.Off, FeatureStatus.On
        };
    }
}
