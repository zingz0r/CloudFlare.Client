using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Test.Helpers;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using Xunit;

namespace CloudFlare.Client.Test.Accounts
{
    public class AccountsUnitTests
    {
        private readonly WireMockServer _wireMockServer;

        public AccountsUnitTests()
        {
            _wireMockServer = WireMockServer.Start();
        }

        [Fact]
        public async Task TestGetAccountsAsync()
        {
            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(AccountTestData.AccountsData)));

            using var client = new CloudFlareClient(new WireMockConnection(_wireMockServer.Urls.FirstOrDefault()).ConnectionInfo);

            var accounts = await client.Accounts.GetAsync();

            accounts.Result.Should().BeEquivalentTo(AccountTestData.AccountsData);
        }

        [Fact]
        public async Task TestGetAccountDetailsAsync()
        {
            var account = AccountTestData.AccountsData.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{account.Id}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                    .WithBody(WireMockResponseHelper.CreateTestResponse(account)));

            using var client = new CloudFlareClient(new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo);

            var accountDetails = await client.Accounts.GetDetailsAsync(account.Id);

            accountDetails.Result.Should().BeEquivalentTo(account);
        }

        [Fact]
        public async Task UpdateAccountAsync()
        {
            var account = AccountTestData.AccountsData.First();

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{account.Id}").UsingPut())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(x =>
                {
                    var body = JsonConvert.DeserializeObject<Account>(x.Body);
                    var acc = AccountTestData.AccountsData.First(y => y.Id == body.Id).DeepClone();

                    acc.Id = body.Id;
                    acc.Name = body.Name;
                    acc.Settings = body.Settings;

                    return WireMockResponseHelper.CreateTestResponse(acc);
                }));

            using var client = new CloudFlareClient(new WireMockConnection(_wireMockServer.Urls.FirstOrDefault()).ConnectionInfo);

            var updatedAccount = await client.Accounts.UpdateAsync(account.Id, "New Name", new AdditionalAccountSettings
            {
                EnforceTwoFactorAuthentication = true
            });

            updatedAccount.Result.Name.Should().Be("New Name");
            updatedAccount.Result.Settings.EnforceTwoFactorAuthentication.Should().BeTrue();
            updatedAccount.Result.Should().BeEquivalentTo(account, opt => opt.Excluding(x => x.Name).Excluding(x => x.Settings.EnforceTwoFactorAuthentication));
        }
    }
}
