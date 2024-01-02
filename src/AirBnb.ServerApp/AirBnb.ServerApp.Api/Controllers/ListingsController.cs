using AirBnb.Server.Api.Models.Dtos;
using AirBnb.ServerApp.Application.Listings.Models;
using AirBnb.ServerApp.Application.Listings.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirBnb.Server.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingsController(IMapper mapper) : ControllerBase
{
    [HttpGet("availability")]
    public async Task<IActionResult> GetListingAvailability(
        [FromQuery] ListingAvailabilityFilter filter,
        [FromServices] IListingOrchestrationService listingCategoryService
    )
    {
        var result = await listingCategoryService.GetByAvailabilityAsync(filter);
        return result.Any() ? Ok(mapper.Map<IEnumerable<ListingCategoryDto>>(result)) : NoContent();
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetListingCategories([FromServices] IListingCategoryService listingCategoryService)
    {
        var result = await listingCategoryService.GetAsync(new ListingCategoryFilter());
        return result.Any() ? Ok(mapper.Map<IEnumerable<ListingCategoryDto>>(result)) : NoContent();
    }
}