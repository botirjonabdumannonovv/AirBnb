using AirBnb.ServerApp.Domain.Common.Entities;

namespace AirBnb.ServerApp.Domain.Entities;

/// <summary>
/// Represents a listing media
/// </summary>
public class ListingMedia : Entity
{
    /// <summary>
    /// Gets or sets listing id
    /// </summary>
    public Guid ListingId { get; set; }

    /// <summary>
    /// Gets or sets listing
    /// </summary>
    public Guid StorageFileId { get; set; }
    
    /// <summary>
    /// Gets or sets listing
    /// </summary>
    public Listing Listing { get; set; } = default!;
    
    /// <summary>
    /// Gets or sets storage file
    /// </summary>
    public StorageFile StorageFile { get; set; } = default!;
}