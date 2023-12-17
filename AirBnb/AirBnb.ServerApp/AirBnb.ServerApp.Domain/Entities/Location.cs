using AirBnb.ServerApp.Domain.Common.Entities;

namespace AirBnb.ServerApp.Domain.Entities;

public class Location : SoftDeletedEntity
{
    public string ImageUrl { get; init; } = default!;

    public string Name { get; init; } = default!;
    
    public int BuiltYear { get; init; }
    
    public int PricePerNight { get; init; }
    
    public float FeedBack { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public virtual LocationCategory? Category { get; init; }
}