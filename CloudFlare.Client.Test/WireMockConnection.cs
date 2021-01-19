using System;
using CloudFlare.Client.Api.Authentication;
using CloudFlare.Client.Contexts;

namespace CloudFlare.Client.Test
{
    public class WireMockConnection
    {
        public static string EmailAddress { get; } = "test@tothnet.hu";
        public static string Key { get; } = "p@ssw0rd";
        public static string Token { get; } = "8M7wS6hCpXVc-DoRnPPY_UCWPgy8aea4Wy6kCe5T";
        public static ApiKeyAuthentication ApiKeyAuthentication { get; } = new(EmailAddress, Key);
        public static ApiTokenAuthentication ApiTokenAuthentication { get; } = new(Token);

        public ConnectionInfo ConnectionInfo { get; }

        public WireMockConnection(string address)
        {
            ConnectionInfo = new ConnectionInfo
            {
                Address = new Uri(address)
            };
        }
    }
}