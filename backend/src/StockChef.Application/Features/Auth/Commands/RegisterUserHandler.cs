using MediatR;
using Microsoft.Extensions.Logging;
using StockChef.Application.Common;
using StockChef.Application.Features.Auth.DTOs;
using StockChef.Application.Interfaces;
using StockChef.Domain.Entities;

namespace StockChef.Application.Features.Auth.Commands;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<AuthResponseDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IJwtService _jwtService;
    private readonly ILogger<RegisterUserHandler> _logger;

    public RegisterUserHandler(
    IUserRepository userRepository,
    IRefreshTokenRepository refreshTokenRepository,
    IJwtService jwtService,
    ILogger<RegisterUserHandler> logger)
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
        _jwtService = jwtService;
        _logger = logger;
    }

    public async Task<Result<AuthResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
            return Result<AuthResponseDto>.Failure("Email already exists");

        var passwordHash = PasswordHasher.Hash(request.Password);

        var user = new User(request.Name, request.Email, passwordHash);

        await _userRepository.AddAsync(user);

        await _refreshTokenRepository.AddAsync(new RefreshToken
        {
            Token = refreshToken,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        });
        
        await _context.SaveChangesAsync();

        var accessToken = _jwtService.GenerateToken(user.Id, user.Email);
        var refreshToken = _jwtService.GenerateRefreshToken();

        await _context.RefreshTokens.AddAsync(new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = refreshToken,
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddDays(7)
        });

        await _context.SaveChangesAsync();

        return Result<AuthResponseDto>.Ok(new AuthResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        });
    }
}