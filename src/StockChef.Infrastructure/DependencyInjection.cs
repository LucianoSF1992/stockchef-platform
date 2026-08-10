using Microsoft.Extensions.DependencyInjection;
using StockChef.Application.Interfaces;
using StockChef.Infrastructure.Repositories;

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

        return services;
    }
}