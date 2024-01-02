namespace AirBnb.ServerApp.Application.RequestContexts.Models;

/// <summary>
/// Represents request context
/// </summary>
public class RequestContext
{
    /// <summary>
    /// Gets or sets user info
    /// </summary>
    public UserInfo? UserInfo { get; set; } = default!;
}