using StockChef.Domain.Enums;

namespace StockChef.Application.DTOs.StockMovements;

public class StockMovementDto
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public decimal Quantity { get; set; }

    public StockMovementType MovementType { get; set; }

    public DateTime MovementDate { get; set; }

    public string? Reason { get; set; }
}