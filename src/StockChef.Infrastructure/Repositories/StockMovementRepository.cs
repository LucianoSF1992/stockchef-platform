using Microsoft.EntityFrameworkCore;
using StockChef.Application.Interfaces;
using StockChef.Domain.Entities;
using StockChef.Infrastructure.Persistence;

namespace StockChef.Infrastructure.Repositories;

public class StockMovementRepository : IStockMovementRepository
{
    private readonly StockChefDbContext _context;

    public StockMovementRepository(StockChefDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StockMovement>> GetAllAsync()
    {
        return await _context.StockMovements
            .Include(m => m.Product)
            .ToListAsync();
    }

    public async Task<StockMovement?> GetByIdAsync(Guid id)
    {
        return await _context.StockMovements
            .Include(m => m.Product)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(StockMovement stockMovement)
    {
        await _context.StockMovements.AddAsync(stockMovement);

        await _context.SaveChangesAsync();
    }
}