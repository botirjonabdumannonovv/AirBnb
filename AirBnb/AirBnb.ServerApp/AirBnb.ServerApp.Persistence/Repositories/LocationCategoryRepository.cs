﻿using System.Linq.Expressions;
using AirBnb.ServerApp.Domain.Entities;
using AirBnb.ServerApp.Persistence.DataContexts;
using AirBnb.ServerApp.Persistence.Repositories.Interfaces;

namespace AirBnb.ServerApp.Persistence.Repositories;

public class LocationCategoryRepository: EntityRepositoryBase<LocationCategory, AppDbContext>, ILocationCategoryRepository
{
    public LocationCategoryRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public ValueTask<LocationCategory?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<LocationCategory> CreateAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(locationCategory, saveChanges, cancellationToken);
    }

    public ValueTask<LocationCategory> UpdateAsync(LocationCategory locationCategory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(locationCategory, saveChanges, cancellationToken);
    }

    public ValueTask<LocationCategory?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }
}