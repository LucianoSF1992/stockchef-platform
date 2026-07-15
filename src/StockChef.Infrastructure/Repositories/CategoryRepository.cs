using Microsoft.EntityFrameworkCore;
using StockChef.Application.Interfaces;
using StockChef.Domain.Entities;
using StockChef.Infrastructure.Persistence;

namespace StockChef.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly StockChefDbContext _context;

    public CategoryRepository(StockChefDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }
}