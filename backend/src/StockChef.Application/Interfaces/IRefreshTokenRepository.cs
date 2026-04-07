using StockChef.Domain.Entities;

namespace StockChef.Application.Interfaces;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken token);
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task DeleteAsync(RefreshToken token);
}