using MediatR;
using Microsoft.Extensions.Logging;
using StockChef.Application.Common;
using StockChef.Application.Features.Auth.DTOs;
using StockChef.Application.Interfaces;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, Result<AuthResponseDto>>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly ILogger<RefreshTokenHandler> _logger;

    public RefreshTokenHandler(
        IRefreshTokenRepository refreshTokenRepository,
        IUserRepository userRepository,
        IJwtService jwtService,
        ILogger<RefreshTokenHandler> logger)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
        _jwtService = jwtService;
        _logger = logger;
    }

    public async Task<Result<AuthResponseDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var storedToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);

        if (storedToken == null || storedToken.ExpiresAt < DateTime.UtcNow)
        {
            return Result<AuthResponseDto>.Failure("Invalid refresh token");
        }

        var user = await _userRepository.GetByIdAsync(storedToken.UserId);

        if (user == null)
            return Result<AuthResponseDto>.Failure("User not found");

        // 🔥 invalida token antigo
        await _refreshTokenRepository.DeleteAsync(storedToken);

        // 🔥 gera novos tokens
        var newAccessToken = _jwtService.GenerateToken(user.Id, user.Email);
        var newRefreshToken = _jwtService.GenerateRefreshToken();

        await _refreshTokenRepository.AddAsync(new Domain.Entities.RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = newRefreshToken,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        });

        _logger.LogInformation("Refresh token usado com sucesso para user {UserId}", user.Id);

        return Result<AuthResponseDto>.Ok(new AuthResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken
        });
    }
}