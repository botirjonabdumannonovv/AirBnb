using AirBnB.Infrastructure.Extensions;
using AirBnb.Server.Api.Dtos;
using AirBnb.ServerApp.Application.Common.Services;
using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Infrastructure.Common.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AirBnb.Server.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationCategoriesController(ILocationCategoryService locationCategoryService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetLocationCategoryService(
        [FromQuery] FilterPagination filterPagination,
        [FromServices] IOptions<ApiSettings> apiSettings,
        CancellationToken cancellationToken = default)
    {
        var querySpecification =
            new QuerySpecification<LocationCategory>(filterPagination.PageSize, filterPagination.PageToken);
        var result = await locationCategoryService.GetAsync(querySpecification, cancellationToken: cancellationToken);
        var locationCategories = result.Select(locationCategory => new LocationCategoryDto
        {
            Id = locationCategory.Id,
            Name = locationCategory.Name,
            ImageUrl = locationCategory.ImageUrl.ToUrl(apiSettings.Value.ApiUrl),
        });
        
        return locationCategories.Any() ? Ok(locationCategories) : BadRequest();
    }
}