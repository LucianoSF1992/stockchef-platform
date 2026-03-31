using StockChef.Domain.Entities;

namespace StockChef.Application.Interfaces;

public interface IProductRepository
{
    Task AddAsync(Product product);
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}