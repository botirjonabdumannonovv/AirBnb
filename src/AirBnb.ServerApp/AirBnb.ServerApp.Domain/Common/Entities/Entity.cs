using AirBnb.ServerApp.Domain.Common.Entities.Interfaces;

namespace AirBnb.ServerApp.Domain.Common.Entities;

public class Entity : IEntity
{
    public Guid Id { get; set; }
}