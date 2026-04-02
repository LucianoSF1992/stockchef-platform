using MediatR;
using Microsoft.Extensions.Logging;
using StockChef.Application.Common;
using StockChef.Application.Features.Auth.DTOs;
using StockChef.Application.Interfaces;
using StockChef.Domain.Entities;
using StockChef.Infrastructure.Persistence;

namespace StockChef.Application.Features.Auth.Commands;

public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<AuthResponseDto>>
{
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;
    private readonly ILogger<RegisterUserHandler> _logger;

    public RegisterUserHandler(
        AppDbContext context,
        IJwtService jwtService,
        ILogger<RegisterUserHandler> logger)
    {
        _context = context;
        _jwtService = jwtService;
        _logger = logger;
    }

    public async Task<Result<AuthResponseDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (_context.Users.Any(u => u.Email == request.Email))
            return Result<AuthResponseDto>.Failure("Email already exists");

        var passwordHash = PasswordHasher.Hash(request.Password);

        var user = new User(request.Name, request.Email, passwordHash);

        await _context.Users.AddAsync(user);
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