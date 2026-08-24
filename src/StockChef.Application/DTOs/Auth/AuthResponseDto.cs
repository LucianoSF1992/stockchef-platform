namespace StockChef.Application.DTOs.Auth;

public record AuthResponseDto(
    string Token,
    DateTime ExpiresAt);
