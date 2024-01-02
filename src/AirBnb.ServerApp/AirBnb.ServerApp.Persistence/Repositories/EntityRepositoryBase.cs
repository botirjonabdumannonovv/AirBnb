using System.Linq.Expressions;
using AirBnb.ServerApp.Domain.Common.Entities;
using AirBnb.ServerApp.Domain.Common.Query;
using AirBnb.ServerApp.Domain.Exceptions;
using AirBnb.ServerApp.Domain.Extensions;
using AirBnb.ServerApp.Persistence.Caching.Brokers;
using AirBnb.ServerApp.Persistence.Caching.Models;
using AirBnb.ServerApp.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace AirBnb.ServerApp.Persistence.Repositories;

/// <summary>
/// Provides base functionality for entity repositories
/// </summary>
/// <typeparam name="TEntity">Type of entity</typeparam>
/// <typeparam name="TContext">Type of context</typeparam>
public class EntityRepositoryBase<TEntity, TContext>(TContext dbContext, ICacheBroker cacheBroker, CacheEntryOptions? cacheEntryOptions = default)
    where TEntity : class, IEntity where TContext : DbContext
{
    protected TContext DbContext => dbContext;
    protected DbSetAsyncQueryProviderResolver<TEntity> AsyncQueryProviderResolver => new(DbContext.Set<TEntity>());

    protected IQueryable<TEntity> QuerySource =>
        cacheEntryOptions is null
            ? DbContext.Set<TEntity>()
            : DbContext.Set<TEntity>()
                .AddCaching(AsyncQueryProviderResolver, new EfCoreExpressionCacheKeyResolver(), cacheBroker.GetCacheResolver(cacheEntryOptions));

    /// <summary>
    /// Retrieves a list of entities based on query specification.
    /// </summary>
    /// <param name="querySpecification">The query specification to apply.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A list of entities that match the given query specification.</returns>
    protected async ValueTask<IList<TEntity>> GetAsync(QuerySpecification<TEntity> querySpecification, CancellationToken cancellationToken = default)
    {
        var cacheKey = querySpecification.CacheKey;

        if (cacheEntryOptions is not null)
        {
            var test = await cacheBroker.TryGetAsync<List<TEntity>>(cacheKey, cancellationToken);
            if (test.Result) return test.Value!;
        }

        var initialQuery = DbContext.Set<TEntity>().AsQueryable();

        if (querySpecification.AsNoTracking) initialQuery = initialQuery.AsNoTracking();
        initialQuery = initialQuery.ApplySpecification(querySpecification);
        var foundEntities = await initialQuery.ToListAsync(cancellationToken);

        if (cacheEntryOptions is not null) await cacheBroker.SetAsync(cacheKey, foundEntities, cacheEntryOptions, cancellationToken);

        return foundEntities;
    }

    /// <summary>
    /// Retrieves a list of entities based on query specification.
    /// </summary>
    /// <param name="predicate">Predicate of query to be applied as filter</param>
    /// <param name="asNoTracking">Determines whether to track the query result or not </param>
    /// <returns>A list of entities that match the given query specification.</returns>
    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = null, bool asNoTracking = false)
    {
        var initialQuery = asNoTracking ? QuerySource.AsNoTracking() : QuerySource;

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        return initialQuery;

        return predicate is null ? initialQuery : initialQuery.Where(predicate);
    }

    /// <summary>
    /// Executes the given data access function asynchronously.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="T">The return type of the data access function.</typeparam>
    /// <param name="entityId">Id of entity</param>
    /// <param name="dataAccessFunc">The data access function to execute.</param>
    /// <returns>
    /// The result of the data access function.
    /// </returns>
    /// <exception cref="Exception">Thrown if the execution of the data access function fails.</exception>
    private static async ValueTask<T?> ExecuteAsync<T>(Guid entityId, Func<Task<T?>> dataAccessFunc)
    {
        var result = await dataAccessFunc.GetValueAsync();
        if (!result.IsSuccess)
            throw MapEfCoreException(entityId, result.Exception!);

        return result.Data;
    }

    /// <summary>
    /// Maps the given Entity Framework Core exception to a custom exception based on the entity and the exception type.
    /// </summary>
    /// <param name="entityId">Id of entity</param>
    /// <param name="exception">The original Entity Framework Core exception.</param>
    /// <returns>The mapped exception.</returns>
    private static Exception MapEfCoreException(Guid entityId, Exception exception)
    {
        return exception switch
        {
            DbUpdateConcurrencyException dbUpdateConcurrencyException => new EntityConflictException<TEntity>(entityId, dbUpdateConcurrencyException),
            DbUpdateException dbUpdateException => MapDbUpdateException(entityId, dbUpdateException),
            _ => exception
        };
    }

    /// <summary>
    /// Maps a <see cref="DbUpdateException"/> to the corresponding entity exception.
    /// </summary>
    /// <param name="entityId">Id of entity</param>
    /// <param name="exception">The <see cref="DbUpdateException"/> to be handled.</param>
    /// <returns>The mapped <see cref="Exception"/>.</returns>
    /// <exception cref="EntityConflictException{TEntity}">Thrown when the <paramref name="exception"/> represents a foreign key or unique constraint violation.</exception>
    /// <exception cref="EntityExceptionBase">Thrown when the <paramref name="exception"/> is not related to a constraint violation.</exception>
    private static EntityExceptionBase MapDbUpdateException(Guid entityId, DbUpdateException exception)
    {
        if (exception.InnerException is not NpgsqlException postgresException)
            return new EntityExceptionBase(entityId, innerException: exception);

        switch (postgresException.ErrorCode)
        {
            case 547: // foreign key constraint violation
            case 2601: // unique constraint violation for index
            case 2627: // unique constraint violation for primary key
                throw new EntityConflictException<TEntity>(entityId, exception);
            default:
                throw new EntityExceptionBase(entityId, innerException: exception);
        }
    }
}