using Microsoft.EntityFrameworkCore;
using StockChef.Domain.Entities;

namespace StockChef.Infrastructure.Persistence;

public class StockChefDbContext : DbContext
{
    public StockChefDbContext(DbContextOptions<StockChefDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Supplier> Suppliers => Set<Supplier>();

    public DbSet<Product> Products => Set<Product>();

    public DbSet<StockMovement> StockMovements => Set<StockMovement>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(StockChefDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}