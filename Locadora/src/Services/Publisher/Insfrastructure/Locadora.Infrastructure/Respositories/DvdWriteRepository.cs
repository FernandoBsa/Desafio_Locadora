using Locadora.Application.Contracts;
using Locadora.Domain.Entities;
using Locadora.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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

    public async Task<bool> Update(Dvd entity)
    {
        _context.Dvds.Update(entity);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        await _context.Dvds.Where(d => d.Id == id).ExecuteDeleteAsync();

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Dvd> Get(Guid id)
    {
        return await _context.Dvds.FindAsync(id);
    }
}