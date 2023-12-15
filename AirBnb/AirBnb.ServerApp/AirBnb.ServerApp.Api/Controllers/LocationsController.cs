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
public class LocationsController(ILocationService locationService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] FilterPagination filterPagination,
        CancellationToken cancellationToken)
    {
        var querySpecification =
            new QuerySpecification<Location>(filterPagination.PageSize, filterPagination.PageToken);

        var result = await locationService.GetAsync(querySpecification, true, cancellationToken);

        return result.Any() ? Ok(mapper.Map<IEnumerable<LocationDto>>(result)) : NoContent();
    }

    [HttpGet("{locationId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid locationId)
    {
        var result = await locationService.GetByIdAsync(locationId);
        return result is not null ? Ok(mapper.Map<LocationDto>(result)) : NoContent();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] LocationDto locationDto)
    {
        var result = await locationService.CreateAsync(mapper.Map<Location>(locationDto));

        return CreatedAtAction(
            nameof(GetById), new
            {
                Id = result.Id
            },
            result
        );
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromQuery] LocationDto locationDto)
    {
        var result = await locationService.UpdateAsync(mapper.Map<Location>(locationDto));

        return Ok(result);
    }

    [HttpDelete("{locationId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid locationId)
    {
        await locationService.DeleteByIdAsync(locationId);

        return Ok();
    }
}