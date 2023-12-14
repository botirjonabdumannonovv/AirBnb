using System.Linq.Expressions;
using AirBnb.ServerApp.Application.Common.Services;
using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Infrastructure.Validators;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;
using FluentValidation;

namespace AirBnb.ServerApp.Infrastructure.Common.Identity.Services;

public class LocationCategoryService(ILocationCategoryRepository locationCategoryRepository, LocationCategoryValidator validator) : ILocationCategoryService
{
    public IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default, bool asNoTracking = false)
    {
        return locationCategoryRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return locationCategoryRepository.GetAsync(querySpecification, asNoTracking, cancellationToken);
    }

    public ValueTask<LocationCategory?> GetByIdAsync(Guid locationCategoryId, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        return locationCategoryRepository.GetByIdAsync(locationCategoryId, asNoTracking, cancellationToken);
    }

    public ValueTask<LocationCategory> CreateAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(locationCategory);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        return locationCategoryRepository.CreateAsync(locationCategory, saveChanges, cancellationToken);
    }

    public ValueTask<LocationCategory> UpdateAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(locationCategory);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        return locationCategoryRepository.UpdateAsync(locationCategory, saveChanges, cancellationToken);
    }

    public ValueTask<LocationCategory?> DeleteByIdAsync(Guid locationCategoryId, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return locationCategoryRepository.DeleteByIdAsync(locationCategoryId, saveChanges, cancellationToken);
    }
}