using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Api.Parameters.Endpoints;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Test.TestData;
using FluentAssertions;
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
            _wireMockServer = WireMockServer.Start(62316);
        }

        [Fact]
        public async Task TestGetAccountsAsync()
        {
            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(
                    JsonConvert.SerializeObject(new CloudFlareResult<IReadOnlyList<Account>>(
                        AccountTestData.AccountsData,
                        AccountTestData.ResultInfo,
                        true,
                        AccountTestData.ErrorDetails,
                        AccountTestData.ApiErrors,
                        AccountTestData.TimingInfo))));

            using var client = new CloudFlareClient(new WireMockConnection(_wireMockServer.Urls.FirstOrDefault()).ConnectionInfo);

            var accounts = await client.Accounts.GetAsync();

            accounts.Should().NotBeNull();
            accounts.Success.Should().BeTrue();
            accounts.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task TestGetAccountDetailsAsync()
        {
            var accountId = AccountTestData.AccountsData.First().Id;

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(
                    JsonConvert.SerializeObject(new CloudFlareResult<Account>(
                        AccountTestData.AccountsData.First(),
                        AccountTestData.ResultInfo,
                        true,
                        AccountTestData.ErrorDetails,
                        AccountTestData.ApiErrors,
                        AccountTestData.TimingInfo))));

            using var client = new CloudFlareClient(new WireMockConnection(_wireMockServer.Urls.First()).ConnectionInfo);

            var accountDetails = await client.Accounts.GetDetailsAsync(accountId);

            accountDetails.Should().NotBeNull();
            accountDetails.Success.Should().BeTrue();
            accountDetails.Errors?.Should().BeEmpty();
        }

        [Fact]
        public async Task UpdateAccountAsync()
        {
            var accountId = AccountTestData.AccountsData.First().Id;

            _wireMockServer
                .Given(Request.Create().WithPath($"/{AccountEndpoints.Base}/{accountId}").UsingPut())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(x =>
                {
                    var body = JsonConvert.DeserializeObject<Account>(x.Body);
                    var account = AccountTestData.AccountsData.First(y => y.Id == body.Id);

                    account.Id = body.Id;
                    account.Name = body.Name;
                    account.Settings = body.Settings;

                    return JsonConvert.SerializeObject(new CloudFlareResult<Account>(
                        account,
                        AccountTestData.ResultInfo,
                        true,
                        AccountTestData.ErrorDetails,
                        AccountTestData.ApiErrors,
                        AccountTestData.TimingInfo));
                }));

            using var client = new CloudFlareClient(new WireMockConnection(_wireMockServer.Urls.FirstOrDefault()).ConnectionInfo);

            var updatedAccount = await client.Accounts.UpdateAsync(accountId, "New Name", new AdditionalAccountSettings
            {
                EnforceTwoFactorAuthentication = true
            });

            updatedAccount.Result.Should().BeEquivalentTo(AccountTestData.AccountsData.First(x => x.Id == accountId));
            updatedAccount.Should().NotBeNull();
            updatedAccount.Success.Should().BeTrue();
            updatedAccount.Errors?.Should().BeEmpty();
        }
    }
}
