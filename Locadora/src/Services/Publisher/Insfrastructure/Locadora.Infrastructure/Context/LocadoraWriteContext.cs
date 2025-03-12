using Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infrastructure.Context;

public class LocadoraWriteContext : DbContext
{
    public LocadoraWriteContext()
    {
        
    }

    public LocadoraWriteContext(DbContextOptions<LocadoraWriteContext> options) : base(options)
    {
        
    }

    public DbSet<Director> Directors { get; set; }
    public DbSet<Dvd> Dvds { get; set; }
}