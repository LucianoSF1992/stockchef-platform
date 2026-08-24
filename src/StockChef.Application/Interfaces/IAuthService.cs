using StockChef.Application.DTOs.Auth;

namespace StockChef.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(
        RegisterDto request,
        CancellationToken cancellationToken = default);

    Task<AuthResponseDto> LoginAsync(
        LoginDto request,
        CancellationToken cancellationToken = default);
}
