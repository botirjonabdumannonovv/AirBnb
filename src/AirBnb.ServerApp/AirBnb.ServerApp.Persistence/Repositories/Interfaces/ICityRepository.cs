using System.Linq.Expressions;
using AirBnb.ServerApp.Domain.Entities;

namespace AirBnb.ServerApp.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines city repository functionalities
/// </summary>
public interface ICityRepository
{
    /// <summary>
    /// Retrieves a list of cities based on predicate
    /// </summary>
    /// <param name="predicate">Predicate of query to be applied as filter</param>
    /// <param name="asNoTracking">Determines whether to track the query result or not </param>
    /// <returns>A list of cities that match the given predicate.</returns>
    IQueryable<City> Get(Expression<Func<City, bool>>? predicate = null, bool asNoTracking = false);
}