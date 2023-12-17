using AirBnb.ServerApp.Domain.Common.Entities;

namespace AirBnb.ServerApp.Domain.Common.Query;

public interface IQueryConvertible<TEntity> where TEntity : IEntity
{
    QuerySpecification<TEntity> ToQuerySpecification();
}