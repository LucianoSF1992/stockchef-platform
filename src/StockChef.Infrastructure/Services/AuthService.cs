using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockChef.Application.DTOs.Auth;
using StockChef.Application.Interfaces;
using StockChef.Infrastructure.Identity;

namespace StockChef.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto> RegisterAsync(
        RegisterDto request,
        CancellationToken cancellationToken = default)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);

        if (existingUser is not null)
            throw new InvalidOperationException("E-mail já cadastrado.");

        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(
            user,
            request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(
                " ",
                result.Errors.Select(error => error.Description));

            throw new InvalidOperationException(errors);
        }

        return GenerateToken(user);
    }

    public async Task<AuthResponseDto> LoginAsync(
        LoginDto request,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
            throw new UnauthorizedAccessException(
                "E-mail ou senha inválidos.");

        var passwordValid = await _userManager.CheckPasswordAsync(
            user,
            request.Password);

        if (!passwordValid)
            throw new UnauthorizedAccessException(
                "E-mail ou senha inválidos.");

        return GenerateToken(user);
    }

    private AuthResponseDto GenerateToken(ApplicationUser user)
    {
        var key = _configuration["Jwt:Key"]
            ?? throw new InvalidOperationException(
                "JWT Key não configurada.");

        var issuer = _configuration["Jwt:Issuer"]
            ?? throw new InvalidOperationException(
                "JWT Issuer não configurado.");

        var expirationMinutes = int.Parse(
            _configuration["Jwt:ExpirationMinutes"] ?? "120");

        var expiresAt = DateTime.UtcNow.AddMinutes(expirationMinutes);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Name, user.UserName!)
        };

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: issuer,
            claims: claims,
            expires: expiresAt,
            signingCredentials: credentials);

        return new AuthResponseDto(
            new JwtSecurityTokenHandler().WriteToken(token),
            expiresAt);
    }
}
