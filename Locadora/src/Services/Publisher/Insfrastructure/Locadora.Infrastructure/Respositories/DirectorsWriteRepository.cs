using Locadora.Application.Contracts;
using Locadora.Domain.Entities;
using Locadora.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infrastructure.Respositories;

public class DirectorsWriteRepository : IDirectorsWriteRepository
{
    private readonly LocadoraWriteContext _context;

    public DirectorsWriteRepository(LocadoraWriteContext context)
    {
        _context = context;
    }
    public async Task<bool> Create(Director entity)
    {
        await _context.Directors.AddAsync(entity);

        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Update(Director entity)
    {
        _context.Directors.Update(entity);
        
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Delete(Guid id)
    {
        await _context.Directors.Where(d => d.Id == id).ExecuteDeleteAsync();

        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<Director> Get(Guid id)
    {
        return await _context.Directors.FindAsync(id);
    }
   public async Task<Director> GetDirectorWithMovies(Guid id)
    {
        return await _context.Directors.AsNoTracking()
            .Include(d => d.Dvds)
            .Where(d => d.Id == id)
            .FirstOrDefaultAsync();
    }
}