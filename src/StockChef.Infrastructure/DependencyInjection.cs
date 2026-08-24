using Microsoft.Extensions.DependencyInjection;
using StockChef.Application.Interfaces;
using StockChef.Infrastructure.Identity;
using StockChef.Infrastructure.Persistence;
using StockChef.Infrastructure.Repositories;
using StockChef.Infrastructure.Services;

namespace StockChef.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<IStockMovementRepository, StockMovementRepository>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddIdentityCore<ApplicationUser>(options =>
        {
            options.User.RequireUniqueEmail = true;

            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = true;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
        })
        .AddEntityFrameworkStores<StockChefDbContext>();

        return services;
    }
}
