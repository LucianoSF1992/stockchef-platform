using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockChef.Domain.Entities;
using StockChef.Infrastructure.Identity;

namespace StockChef.Infrastructure.Persistence;

public class StockChefDbContext : IdentityDbContext<ApplicationUser>
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
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(StockChefDbContext).Assembly);
    }
}
