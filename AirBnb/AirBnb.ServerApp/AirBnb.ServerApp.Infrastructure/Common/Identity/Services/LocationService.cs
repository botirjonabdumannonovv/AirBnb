using System.Linq.Expressions;
using AirBnb.ServerApp.Application.Common.Services;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Infrastructure.Validators;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;
using FluentValidation;

namespace AirBnb.ServerApp.Infrastructure.Common.Services;

public class LocationService(ILocationRepository locationRepository, LocationValidator validator) : ILocationService
{
    public IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false)
    {
        return locationRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Location?> GetByIdAsync(Guid locationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return locationRepository.GetByIdAsync(locationId, asNoTracking, cancellationToken);
    }

    public ValueTask<Location> CreateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(location);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return locationRepository.CreateAsync(location, saveChanges, cancellationToken);
    }

    public ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(location);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return locationRepository.UpdateAsync(location, saveChanges, cancellationToken);
    }

    public ValueTask<Location?> DeleteByIdAsync(Guid locationId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return locationRepository.DeleteByIdAsync(locationId, saveChanges, cancellationToken);
    }
}