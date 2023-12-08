
using Microsoft.EntityFrameworkCore;
using SeventhServers.Domain.Abstractions.Repositories;

namespace SeventhServers.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = true;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public async Task<bool> Commit()
    {
        return await base.SaveChangesAsync() > 0;
    }
}
