using StockChef.Domain.Entities;

public interface ICompanyRepository
{
    Task AddAsync(Company company);
    Task<Company?> GetByIdAsync(Guid id);
    Task<List<Company>> GetAllAsync();
}