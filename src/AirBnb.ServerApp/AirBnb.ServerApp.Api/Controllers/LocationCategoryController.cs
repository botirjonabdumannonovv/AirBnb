﻿using AirBnb.Server.Api.Dtos.Models;
using AirBnb.ServerApp.Application.Common.Locations.Services;
using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Infrastructure.Common.Extensions;
using AirBnb.ServerApp.Infrastructure.Common.Locations.Settings;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AirBnb.Server.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationCategoryController(ILocationCategoryService locationCategoryService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get(
        [FromQuery] FilterPagination filterPagination, 
        [FromServices] IOptions<ApiSettings> apiSettings,
        CancellationToken cancellationToken
        )
    {
        var specification = new QuerySpecification<LocationCategory>(filterPagination.PageSize, filterPagination.PageToken);
        var result = await locationCategoryService.GetAsync(specification, true, cancellationToken);

        var locationCategories = result.Select(locationCategory => new LocationCategoryDto()
        {
            Id = locationCategory.Id,
            Name = locationCategory.Name,
            ImageUrl = locationCategory.ImageUrl.ToUrl(apiSettings.Value.ApiUrl)
        });
        return locationCategories.Any() ? Ok(locationCategories) : NotFound();
    }
    
    [HttpGet("{locationId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid locationCategoryId)
    {
        var result = await locationCategoryService.GetByIdAsync(locationCategoryId);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] LocationCategoryDto locationCategoryDto)
    {
        var result = await locationCategoryService.CreateAsync(mapper.Map<LocationCategory>(locationCategoryDto));
        return CreatedAtAction(
            nameof(GetById),
            new
            {
                todoId = result.Id
            },
            result
        );
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] LocationCategoryDto locationCategoryDto)
    {
        var result = await locationCategoryService.UpdateAsync(mapper.Map<LocationCategory>(locationCategoryDto));
        return Ok(result);
    }

    [HttpDelete("{todoId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid locationCategoryId)
    {
        await locationCategoryService.DeleteByIdAsync(locationCategoryId);
        return Ok();
    }
}