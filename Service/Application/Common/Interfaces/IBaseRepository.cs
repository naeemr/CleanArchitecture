using Service.Domain;

namespace Service.Application.Common.Interfaces;

public interface IBaseRepository<TEntity>
	where TEntity : IBaseEntity, IAggregateRoot
{

}
