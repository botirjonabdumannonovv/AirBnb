using AirBnb.ServerApp.Domain.Common.Entities;

namespace AirBnb.ServerApp.Domain.Entities;

/// <summary>
/// Represents a listing for a property
/// </summary>
public class Listing : Entity
{
    /// <summary>
    /// Gets or sets listing name
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the date when an object was built
    /// </summary>
    public DateOnly BuiltDate { get; set; }

    /// <summary>
    /// Gets or sets the address property.
    /// </summary>
    public Address Address { get; set; } = default!;

    /// <summary>
    /// Gets or sets the price per night for the property.
    /// </summary>
    public Money PricePerNight { get; set; } = default!;

    /// <summary>
    /// Gets or sets listing category Id
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Gets or sets listing category
    /// </summary>
    public ListingCategory Category { get; set; } = default!;

    /// <summary>
    /// Gets or sets listing images
    /// </summary>
    public IList<ListingMedia> ImagesStorageFile { get; set; } = new List<ListingMedia>();
}