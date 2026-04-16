using StockChef.Domain.Entities;

public interface IUnitRepository
{
    Task AddAsync(Unit unit);

    Task<List<Unit>> GetAllAsync();

    Task<Unit?> GetByIdAsync(Guid id);

    Task UpdateAsync(Unit unit);

    Task DeleteAsync(Unit unit);
}