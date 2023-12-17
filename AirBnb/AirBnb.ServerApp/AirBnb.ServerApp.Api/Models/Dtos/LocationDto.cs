namespace AirBnb.Server.Api.Dtos;

public class LocationDto
{
    public Guid Id { get; set; }

    public string ImageUrl { get; set; } = default!;
    public string Name { get; set; } = default!;

    public int BuiltYear { get; set; } = default!;

    public int PricePerNight { get; set; } = default!;
    
    public float FeedBack { get; set; }
}