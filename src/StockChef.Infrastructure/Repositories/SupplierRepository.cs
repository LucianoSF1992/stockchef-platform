using Microsoft.EntityFrameworkCore;
using StockChef.Application.Interfaces;
using StockChef.Domain.Entities;
using StockChef.Infrastructure.Persistence;

namespace StockChef.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly StockChefDbContext _context;

    public SupplierRepository(StockChefDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync()
    {
        return await _context.Suppliers
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Supplier?> GetByIdAsync(Guid id)
    {
        return await _context.Suppliers
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Supplier supplier)
    {
        await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        _context.Suppliers.Update(supplier);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);

        if (supplier is null)
            return;

        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();
    }
}