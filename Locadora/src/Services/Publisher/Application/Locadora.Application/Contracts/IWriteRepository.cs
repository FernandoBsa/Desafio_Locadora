using Locadora.Core.DomainObjects;

namespace Locadora.Application.Contracts;

public interface IWriteRepository<T> where T : Entity
{
    Task<bool> Create(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(Guid id);
    Task<T> Get(Guid id);
}