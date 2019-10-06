using System.Collections.Generic;
using System.Linq;
using CloudFlare.Client.Api.CustomHostname;
using CloudFlare.Client.Enumerators;
using CloudFlare.Client.Models;
using CloudFlare.Client.Test.FactAttributes;
using CloudFlare.Client.Test.TheoryAttributes;
using Microsoft.VisualBasic;
using Xunit;

namespace CloudFlare.Client.Test
{
    public static class CustomHostnameUnitTests
    {
        [IgnoreOnEmptyCredentialsTheory]
        [InlineData(null, null, null, null, null, null)]
        [InlineData(null, null, 0, null, null, null)]
        [InlineData(null, null, null, 100, null, null)]
        [InlineData(null, null, null, null, OrderType.Asc, null)]
        [InlineData(null, null, null, null, OrderType.Desc, null)]
        [InlineData(null, null, null, null, null, true)]
        [InlineData(null, null, null, null, null, false)]
        public static void TestGetCustomHostnamesAsync(string hostname, int? page, int? perPage,
            CustomHostnameOrderType? type, OrderType? order, bool? ssl)
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var zoneId = client.GetZonesAsync().Result.Result.First().Id;
                var customHostnames = client.GetCustomHostnamesAsync(zoneId, hostname, page, perPage, type, order, ssl).Result;

                Assert.NotNull(customHostnames);
                Assert.Empty(customHostnames.Errors);
                Assert.True(customHostnames.Success);
            }
        }

        [IgnoreOnEmptyCredentialsTheory]
        [InlineData(null, null, null, null, null, null)]
        [InlineData(null, null, 0, null, null, null)]
        [InlineData(null, null, null, 100, null, null)]
        [InlineData(null, null, null, null, OrderType.Asc, null)]
        [InlineData(null, null, null, null, OrderType.Desc, null)]
        [InlineData(null, null, null, null, null, true)]
        [InlineData(null, null, null, null, null, false)]
        public static void TestGetCustomHostnamesByIdAsync(string id, int? page, int? perPage,
            CustomHostnameOrderType? type, OrderType? order, bool? ssl)
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var zoneId = client.GetZonesAsync().Result.Result.First().Id;
                var customHostnameId = client.GetCustomHostnamesByIdAsync(zoneId, id, page, perPage, type, order, ssl).Result.Result.First().Id;
                var customHostnameDetails = client.GetCustomHostnameDetailsAsync(zoneId, customHostnameId).Result;

                Assert.NotNull(customHostnameDetails);
                Assert.Empty(customHostnameDetails.Errors);
                Assert.True(customHostnameDetails.Success);
            }
        }

        [IgnoreOnEmptyCredentialsFact]
        public static void TestGetCustomHostnameDetailsAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var zoneId = client.GetZonesAsync().Result.Result.First().Id;
                var customHostnameId = client.GetCustomHostnamesAsync(zoneId).Result.Result.First().Id;
                var customHostnameDetails = client.GetCustomHostnameDetailsAsync(zoneId, customHostnameId).Result;

                Assert.NotNull(customHostnameDetails);
                Assert.Empty(customHostnameDetails.Errors);
                Assert.True(customHostnameDetails.Success);
            }
        }
        
        [IgnoreOnEmptyCredentialsFact]
        public static void TestEditCustomHostnameAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var zoneId = client.GetZonesAsync().Result.Result.First().Id;
                var customHostname = client.GetCustomHostnamesAsync(zoneId).Result.Result.First();

                var patchData = new PatchCustomHostname
                {
                    Ssl = new CustomHostnameSsl
                    {
                        Method = MethodType.Http,
                        Settings = new CustomHostnameSslSettings
                        {
                            Ciphers = new List<string>
                            {
                                "ECDHE-RSA-AES128-GCM-SHA256",
                                "AES128-SHA"
                            },
                            Http2 = FeatureStatus.On,
                            MinTlsVersion = TlsVersion.Tls12,
                            Tls13 = FeatureStatus.On
                        },
                    }
                };

                var editCustomHostname = client.EditCustomHostnameAsync(zoneId, patchData).Result;
                
                Assert.NotNull(editCustomHostname);
                Assert.Empty(editCustomHostname.Errors);
                Assert.True(editCustomHostname.Success);

                var updatedCustomHostname = client.GetCustomHostnamesAsync(zoneId,customHostname.Hostname).Result.Result.First();

                Assert.Equal(MethodType.Http, updatedCustomHostname.Ssl.Method);
            }
        }

        [Fact(Skip = "Would cause deleted membership")]
        public static void TestDeleteCustomHostnameAsync()
        {
            using (var client = new CloudFlareClient(Credentials.Credentials.Authentication))
            {
                var zoneId = client.GetZonesAsync().Result.Result.First().Id;
                var customHostname = client.GetCustomHostnamesAsync(zoneId).Result.Result.First();
                var deleteCustomHostname = client.DeleteCustomHostnameAsync(zoneId, customHostname.Hostname).Result;

                Assert.NotNull(deleteCustomHostname);
                Assert.Empty(deleteCustomHostname.Errors);
                Assert.True(deleteCustomHostname.Success);
            }
        }
    }
}
