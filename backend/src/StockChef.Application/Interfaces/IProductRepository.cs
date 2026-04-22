using StockChef.Domain.Entities;

namespace StockChef.Application.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}