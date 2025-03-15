using Locadora.Query.Domain.Models;

namespace Locadora.Query.Application.Contracts;

public interface IDirectorsQueryRepository : IQueryRepository<Director>
{
    Task<Director> GetByName(string name);
}