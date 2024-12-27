﻿using CloudFlare.Client.Enumerators;

namespace CloudFlare.Client.Api.Users.Memberships;

/// <summary>
/// Membership filter
/// </summary>
public class MembershipFilter
{
    /// <summary>
    /// Status of this membership
    /// </summary>
    public MembershipStatus? Status { get; set; }

    /// <summary>
    /// Account name
    /// </summary>
    public string AccountName { get; set; }

    /// <summary>
    /// Field to order memberships by
    /// </summary>
    public MembershipOrder? MembershipOrder { get; set; }
}
