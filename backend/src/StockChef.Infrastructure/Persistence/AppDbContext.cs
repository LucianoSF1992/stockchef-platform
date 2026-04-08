using Microsoft.EntityFrameworkCore;
using StockChef.Domain.Entities;

namespace StockChef.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public DbSet<User> Users => Set<User>();
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public DbSet<Company> Companies { get; set; }
    public DbSet<Unit> Units { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>()
            .HasMany(c => c.Units)
            .WithOne(u => u.Company)
            .HasForeignKey(u => u.CompanyId);
    }
}