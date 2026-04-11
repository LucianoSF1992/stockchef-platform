using Microsoft.EntityFrameworkCore;
namespace StockChef.Infrastructure.Persistence;

public class CompanyRepository : ICompanyRepository
{
    private readonly AppDbContext _context;

    public CompanyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Company company)
    {
        await _context.Companies.AddAsync(company);
        await _context.SaveChangesAsync();
    }

    public async Task<Company?> GetByIdAsync(Guid id)
    {
        return await _context.Companies
            .Include(c => c.Units)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Company>> GetAllAsync()
    {
        return await _context.Companies
            .Include(c => c.Units)
            .ToListAsync();
    }
}