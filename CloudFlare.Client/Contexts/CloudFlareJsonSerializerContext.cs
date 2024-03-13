using System.Collections.Generic;
using System.Text.Json.Serialization;
using CloudFlare.Client.Api.Accounts;
using CloudFlare.Client.Api.Accounts.Member;
using CloudFlare.Client.Api.Accounts.Roles;
using CloudFlare.Client.Api.Accounts.Subscriptions;
using CloudFlare.Client.Api.Accounts.TurnstileWidgets;
using CloudFlare.Client.Api.Parameters.Data;
using CloudFlare.Client.Api.Result;
using CloudFlare.Client.Api.Users;
using CloudFlare.Client.Api.Users.Memberships;
using CloudFlare.Client.Api.Zones;
using CloudFlare.Client.Api.Zones.CustomHostnames;
using CloudFlare.Client.Api.Zones.DnsRecord;
using CloudFlare.Client.Api.Zones.WorkerRoute;
using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Contexts
{
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(double))]
    [JsonSerializable(typeof(char))]
    [JsonSerializable(typeof(Account))]
    [JsonSerializable(typeof(Member))]
    [JsonSerializable(typeof(NewMember))]
    [JsonSerializable(typeof(Membership))]
    [JsonSerializable(typeof(Subscription))]
    [JsonSerializable(typeof(DeletedSubscription))]
    [JsonSerializable(typeof(TurnstileWidget))]
    [JsonSerializable(typeof(NewTurnstileWidget))]
    [JsonSerializable(typeof(UpdatedTurnstileWidget))]
    [JsonSerializable(typeof(Dictionary<string, bool>))]
    [JsonSerializable(typeof(Dictionary<string, MembershipStatus>))]
    [JsonSerializable(typeof(User))]
    [JsonSerializable(typeof(VerifyToken))]
    [JsonSerializable(typeof(CustomHostname))]
    [JsonSerializable(typeof(NewCustomHostname))]
    [JsonSerializable(typeof(ModifiedCustomHostname))]
    [JsonSerializable(typeof(CustomHostnameStatus))]
    [JsonSerializable(typeof(OwnershipVerification))]
    [JsonSerializable(typeof(OwnershipVerificationHttp))]
    [JsonSerializable(typeof(DnsRecord))]
    [JsonSerializable(typeof(NewDnsRecord))]
    [JsonSerializable(typeof(NewDnsRecordBase))]
    [JsonSerializable(typeof(DnsRecordScan))]
    [JsonSerializable(typeof(DnsRecordImport))]
    [JsonSerializable(typeof(ModifiedDnsRecord))]
    [JsonSerializable(typeof(WorkerRoute))]
    [JsonSerializable(typeof(NewWorkerRoute))]
    [JsonSerializable(typeof(ModifiedWorkerRoute))]
    [JsonSerializable(typeof(ZoneSetting<FeatureStatus>))]
    [JsonSerializable(typeof(ZoneSetting<TlsVersion>))]
    [JsonSerializable(typeof(ZoneSetting<SslSetting>))]
    [JsonSerializable(typeof(NewZone))]
    [JsonSerializable(typeof(ModifiedZone))]
    [JsonSerializable(typeof(Srv))]
    [JsonSerializable(typeof(TlsA))]
    [JsonSerializable(typeof(OrderType?))]
    [JsonSerializable(typeof(MembershipStatus?))]
    [JsonSerializable(typeof(MembershipOrder?))]
    [JsonSerializable(typeof(MatchType?))]
    [JsonSerializable(typeof(ZoneStatus?))]
    [JsonSerializable(typeof(CloudFlareResult<object>))]
    [JsonSerializable(typeof(CloudFlareResult<string>))]
    [JsonSerializable(typeof(CloudFlareResult<Account>))]
    [JsonSerializable(typeof(CloudFlareResult<List<Account>>))]
    [JsonSerializable(typeof(CloudFlareResult<IReadOnlyList<Account>>))]
    [JsonSerializable(typeof(CloudFlareResult<User>))]
    [JsonSerializable(typeof(CloudFlareResult<VerifyToken>))]
    [JsonSerializable(typeof(CloudFlareResult<Member>))]
    [JsonSerializable(typeof(CloudFlareResult<List<Member>>))]
    [JsonSerializable(typeof(CloudFlareResult<IReadOnlyList<Member>>))]
    [JsonSerializable(typeof(CloudFlareResult<Membership>))]
    [JsonSerializable(typeof(CloudFlareResult<List<Membership>>))]
    [JsonSerializable(typeof(CloudFlareResult<IReadOnlyList<Membership>>))]
    [JsonSerializable(typeof(CloudFlareResult<Role>))]
    [JsonSerializable(typeof(CloudFlareResult<List<Role>>))]
    [JsonSerializable(typeof(CloudFlareResult<IReadOnlyList<Role>>))]
    [JsonSerializable(typeof(CloudFlareResult<Subscription>))]
    [JsonSerializable(typeof(CloudFlareResult<DeletedSubscription>))]
    [JsonSerializable(typeof(CloudFlareResult<List<Subscription>>))]
    [JsonSerializable(typeof(CloudFlareResult<IReadOnlyList<Subscription>>))]
    [JsonSerializable(typeof(CloudFlareResult<TurnstileWidget>))]
    [JsonSerializable(typeof(CloudFlareResult<List<TurnstileWidget>>))]
    [JsonSerializable(typeof(CloudFlareResult<IReadOnlyList<TurnstileWidget>>))]
    [JsonSerializable(typeof(CloudFlareResult<CustomHostname>))]
    [JsonSerializable(typeof(CloudFlareResult<List<CustomHostname>>))]
    [JsonSerializable(typeof(CloudFlareResult<IReadOnlyList<CustomHostname>>))]
    [JsonSerializable(typeof(CloudFlareResult<DnsRecord>))]
    [JsonSerializable(typeof(CloudFlareResult<List<DnsRecord>>))]
    [JsonSerializable(typeof(CloudFlareResult<IReadOnlyList<DnsRecord>>))]
    [JsonSerializable(typeof(CloudFlareResult<DnsRecordImport>))]
    [JsonSerializable(typeof(CloudFlareResult<DnsRecordScan>))]
    [JsonSerializable(typeof(CloudFlareResult<WorkerRoute>))]
    [JsonSerializable(typeof(CloudFlareResult<List<WorkerRoute>>))]
    [JsonSerializable(typeof(CloudFlareResult<IReadOnlyList<WorkerRoute>>))]
    [JsonSerializable(typeof(CloudFlareResult<Zone>))]
    [JsonSerializable(typeof(CloudFlareResult<List<Zone>>))]
    [JsonSerializable(typeof(CloudFlareResult<IReadOnlyList<Zone>>))]
    [JsonSerializable(typeof(CloudFlareResult<ZoneSetting<FeatureStatus>>))]
    [JsonSerializable(typeof(CloudFlareResult<ZoneSetting<TlsVersion>>))]
    [JsonSerializable(typeof(CloudFlareResult<ZoneSetting<SslSetting>>))]
    internal partial class CloudFlareJsonSerializerContext : JsonSerializerContext
    {
    }
}
