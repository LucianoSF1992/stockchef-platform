using MediatR;
using StockChef.Application.Common;
using StockChef.Application.Features.Auth.DTOs;

public class RefreshTokenCommand : IRequest<Result<AuthResponseDto>>
{
    public string RefreshToken { get; set; } = null!;
}