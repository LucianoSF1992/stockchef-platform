using Microsoft.EntityFrameworkCore;
using StockChef.Domain.Entities;

namespace StockChef.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}