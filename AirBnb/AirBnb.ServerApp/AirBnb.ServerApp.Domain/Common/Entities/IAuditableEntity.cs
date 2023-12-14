namespace AirBnb.ServerApp.Domain.Common.Entities;

public interface IAuditableEntity
{
    DateTimeOffset CreatedTime { get; set; }
    
    DateTimeOffset? ModifiedTime { get; set; }
}