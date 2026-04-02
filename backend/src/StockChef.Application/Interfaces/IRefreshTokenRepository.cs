using StockChef.Domain.Entities;

namespace StockChef.Application.Interfaces;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken token);
}