using AirBnb.Server.Api.Dtos;
using AirBnb.ServerApp.Application.Common.Services;
using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Server.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationCategoriesController(ILocationCategoryService locationCategoryService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] FilterPagination filterPagination,
        CancellationToken cancellationToken)
    {
        var querySpecification =
            new QuerySpecification<LocationCategory>(filterPagination.PageSize, filterPagination.PageToken);

        var result = await locationCategoryService.GetAsync(querySpecification, true,cancellationToken);
        return result.Any() ? Ok(mapper.Map<IEnumerable<LocationCategoryDto>>(result)) : NoContent();
    }

    [HttpGet("{locationCategoryId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid locationCategoryId)
    {
        var result = await locationCategoryService.GetByIdAsync(locationCategoryId);
        return result is not null ? Ok(mapper.Map<LocationDto>(result)) : NoContent();
    }
    
    [HttpPost]
    public async ValueTask<IActionResult> Create([FromQuery] LocationCategoryDto locationCategoryDto)
    {
        var result = await locationCategoryService.CreateAsync(mapper.Map<LocationCategory>(locationCategoryDto));

        return CreatedAtAction(
            nameof(GetById), new
            {
                Id = result.Id
            },
            result
        );
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromQuery] LocationCategoryDto locationCategoryDto)
    {
        var result = await locationCategoryService.UpdateAsync(mapper.Map<LocationCategory>(locationCategoryDto));
        return Ok(result);
    }

    [HttpDelete("{locationCategoryId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid locationCategoryId)
    {
        await locationCategoryService.DeleteByIdAsync(locationCategoryId);
        return Ok();
    }
}