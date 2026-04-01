namespace StockChef.Domain.Entities;

public class RefreshToken
{
    public Guid Id { get; set; }
    public string Token { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }
    public Guid UserId { get; set; }

    public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
}