using AirBnB.Infrastructure.Extensions;
using AirBnb.Server.Api.Dtos;
using AirBnb.ServerApp.Application.Common.Models;
using AirBnb.ServerApp.Application.Common.Services;
using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Infrastructure.Common.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AirBnb.Server.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController(ILocationService locationService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetLocations(
        [FromQuery] LocationFilter locationFilter,
        [FromServices]  IOptions<ApiSettings> apiSettings,
        CancellationToken cancellationToken = default)
    {
        var result = await locationService.GetAsync(locationFilter.ToQuerySpecification(), cancellationToken: cancellationToken);
        var locations = result.Select(location => new LocationDto
        {
            Id = location.Id,
            ImageUrl = location.ImageUrl.ToUrl(apiSettings.Value.ApiUrl),
            Name = location.Name,
            BuiltYear = location.BuiltYear,
            PricePerNight = location.PricePerNight,
            FeedBack = location.FeedBack
        });
        return locations.Any() ? Ok(locations) : NoContent();
    }
}