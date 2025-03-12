using Locadora.Application.Contracts;
using Locadora.Domain.Entities;
using Locadora.Infrastructure.Context;

namespace Locadora.Infrastructure.Respositories;

public class DvdWriteRepository : IDvdsWriteRepository
{
    private readonly LocadoraWriteContext _context;

    public DvdWriteRepository(LocadoraWriteContext context)
    {
        _context = context;
    }

    public async Task<bool> Create(Dvd entity)
    {
        await _context.Dvds.AddAsync(entity);

        return await _context.SaveChangesAsync() > 0;
    }

    public Task<bool> Update(Dvd entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Dvd> Get(Guid id)
    {
        throw new NotImplementedException();
    }
}