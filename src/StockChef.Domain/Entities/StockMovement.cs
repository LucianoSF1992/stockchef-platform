using StockChef.Domain.Common;
using StockChef.Domain.Enums;

namespace StockChef.Domain.Entities;

public class StockMovement : BaseEntity
{
    public Guid ProductId { get; private set; }

    public Product Product { get; private set; } = null!;

    public StockMovementType Type { get; private set; }

    public decimal Quantity { get; private set; }

    public string? Reason { get; private set; }

    private StockMovement()
    {
    }

    public StockMovement(
        Guid productId,
        StockMovementType type,
        decimal quantity,
        string? reason = null)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        ProductId = productId;
        Type = type;
        Quantity = quantity;
        Reason = reason;
    }
}