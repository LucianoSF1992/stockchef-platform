using MediatR;
using StockChef.Application.Common;
using StockChef.Application.Features.Auth.DTOs;

namespace StockChef.Application.Features.Auth.Commands;

public class RegisterUserCommand : IRequest<Result<AuthResponseDto>>
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}