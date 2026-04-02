using MediatR;
using Microsoft.Extensions.Logging;
using StockChef.Application.Common;
using StockChef.Application.Features.Auth.DTOs;
using StockChef.Application.Interfaces;
using StockChef.Domain.Entities;

namespace StockChef.Application.Features.Auth.Commands;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, Result<AuthResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IJwtService _jwtService;
    private readonly ILogger<LoginUserHandler> _logger;

    public LoginUserHandler(
        IUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IJwtService jwtService,
        ILogger<LoginUserHandler> logger)
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _jwtService = jwtService;
        _logger = logger;
    }

    public async Task<Result<AuthResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user is null || !PasswordHasher.Verify(request.Password, user.PasswordHash))
        {
            _logger.LogWarning("Invalid login attempt for email: {Email}", request.Email);
            return Result<AuthResponseDto>.Failure("Invalid credentials");
        }

        var accessToken = _jwtService.GenerateToken(user.Id, user.Email);
        var refreshToken = _jwtService.GenerateRefreshToken();

        await _refreshTokenRepository.AddAsync(new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = refreshToken,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        });

        _logger.LogInformation("User logged in successfully: {Email}", user.Email);

        return Result<AuthResponseDto>.Ok(new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        });
    }
}