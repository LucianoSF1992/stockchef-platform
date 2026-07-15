using StockChef.Domain.Enums;

namespace StockChef.Application.DTOs.StockMovements;

public class CreateStockMovementDto
{
    public Guid ProductId { get; set; }

    public decimal Quantity { get; set; }

    public StockMovementType MovementType { get; set; }

    public string? Reason { get; set; }
}