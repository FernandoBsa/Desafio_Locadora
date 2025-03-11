using Locadora.Domain.Entities;

namespace Locadora.Application.Contracts;

public interface IDirectorsWriteRepository : IWriteRepository<Director>
{
    Task<Director> GetDirectorWithMovies(Guid id);
}