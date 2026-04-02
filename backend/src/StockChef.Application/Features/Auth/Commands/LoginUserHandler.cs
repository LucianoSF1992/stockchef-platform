using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StockChef.Application.Common;
using StockChef.Application.Features.Auth.DTOs;
using StockChef.Application.Interfaces;
using StockChef.Infrastructure.Persistence;

namespace StockChef.Application.Features.Auth.Commands;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, Result<AuthResponseDto>>
{
    private readonly AppDbContext _context;
    private readonly IJwtService _jwtService;
    private readonly ILogger<LoginUserHandler> _logger;

    public LoginUserHandler(
        AppDbContext context,
        IJwtService jwtService,
        ILogger<LoginUserHandler> logger)
    {
        _context = context;
        _jwtService = jwtService;
        _logger = logger;
    }

    public async Task<Result<AuthResponseDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user is null || !PasswordHasher.Verify(request.Password, user.PasswordHash))
            return Result<AuthResponseDto>.Failure("Invalid credentials");

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