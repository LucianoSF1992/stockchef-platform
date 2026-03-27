using StockChef.Domain.Entities;

namespace StockChef.Application.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
}