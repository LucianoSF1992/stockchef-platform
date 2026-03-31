using StockChef.Domain.Entities;

namespace StockChef.Application.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task UpdateAsync(Product product);
}