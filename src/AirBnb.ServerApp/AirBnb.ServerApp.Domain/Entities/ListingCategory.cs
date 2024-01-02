using AirBnb.ServerApp.Domain.Common.Entities;

namespace AirBnb.ServerApp.Domain.Entities;

/// <summary>
/// Represents a category for a listing
/// </summary>
public class ListingCategory : Entity
{
    /// <summary>
    /// Gets or sets the category name
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the category image id
    /// </summary>
    public Guid ImageStorageFileId { get; set; }

    /// <summary>
    /// Gets or sets the category image
    /// </summary>
    public StorageFile ImageStorageFile { get; set; } = default!;
}