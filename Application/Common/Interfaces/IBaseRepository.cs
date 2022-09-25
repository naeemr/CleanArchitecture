using Domain;

namespace Application.Common.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : IBaseEntity, IAggregateRoot
{
    
}
