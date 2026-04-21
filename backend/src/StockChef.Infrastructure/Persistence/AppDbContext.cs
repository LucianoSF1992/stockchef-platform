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

    private readonly ICurrentCompanyService _currentCompanyService;

    public AppDbContext(
        DbContextOptions<AppDbContext> options,
        ICurrentCompanyService currentCompanyService
    ) : base(options)
    {
        _currentCompanyService = currentCompanyService;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .Property(p => p.UnitPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Company>()
            .ToTable("Company")
            .HasMany(c => c.Units)
            .WithOne(u => u.Company)
            .HasForeignKey(u => u.CompanyId);

        modelBuilder.Entity<Unit>()
            .ToTable("Units");

        modelBuilder.Entity<Product>()
            .ToTable("Products");

        modelBuilder.Entity<User>()
            .ToTable("Users");

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ICompanyEntity).IsAssignableFrom(entityType.ClrType))
            {
                var method = typeof(AppDbContext)
                    .GetMethod(nameof(SetGlobalQueryFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
                    .MakeGenericMethod(entityType.ClrType);

                method.Invoke(this, new object[] { modelBuilder });
            }
        }
    }

    
    private void SetGlobalQueryFilter<TEntity>(ModelBuilder modelBuilder)
        where TEntity : class, ICompanyEntity
    {
        modelBuilder.Entity<TEntity>()
            .HasQueryFilter(e => e.CompanyId == _currentCompanyService.GetCompanyId());
    }
}