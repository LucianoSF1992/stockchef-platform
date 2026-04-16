using Microsoft.EntityFrameworkCore;
using StockChef.Infrastructure.Persistence;
using StockChef.Domain.Entities;

public class UnitRepository : IUnitRepository
{
    private readonly AppDbContext _context;

    public UnitRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Unit unit)
    {
        await _context.Units.AddAsync(unit);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Unit>> GetAllAsync()
    {
        return await _context.Units.ToListAsync();
    }

    public async Task<Unit?> GetByIdAsync(Guid id)
    {
        return await _context.Units.FindAsync(id);
    }

    public async Task UpdateAsync(Unit unit)
    {
        _context.Units.Update(unit);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Unit unit)
    {
        _context.Units.Remove(unit);
        await _context.SaveChangesAsync();
    }
}