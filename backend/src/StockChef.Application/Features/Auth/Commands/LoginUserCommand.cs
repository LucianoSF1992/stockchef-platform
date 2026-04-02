using MediatR;
using StockChef.Application.Common;
using StockChef.Application.Features.Auth.DTOs;

namespace StockChef.Application.Features.Auth.Commands;

public class LoginUserCommand : IRequest<Result<AuthResponseDto>>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}