namespace AirBnb.Server.Api.Dtos;

public class LocationDto
{
    public string Name { get; set; } = default!;

    public int BuiltYear { get; set; } = default!;

    public int PricePerNight { get; set; } = default!;
}