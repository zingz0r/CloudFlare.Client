namespace CloudFlare.Client.Api.Display;

/// <summary>
/// Unorderable display options
/// </summary>
public class UnOrderableDisplayOptions
{
    /// <summary>
    /// Page number of paginated result
    /// </summary>
    public int? Page { get; set; }

    /// <summary>
    /// Number of elements per pages
    /// </summary>
    public int? PerPage { get; set; }
}
