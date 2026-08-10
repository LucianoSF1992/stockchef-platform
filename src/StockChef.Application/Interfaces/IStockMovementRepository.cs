using StockChef.Domain.Entities;

namespace StockChef.Application.Interfaces;

public interface IStockMovementRepository
{
    Task<IEnumerable<StockMovement>> GetAllAsync();

    Task<StockMovement?> GetByIdAsync(Guid id);

    Task AddAsync(StockMovement stockMovement);
}