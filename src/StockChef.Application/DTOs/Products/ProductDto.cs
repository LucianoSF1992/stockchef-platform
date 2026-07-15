using StockChef.Domain.Enums;

namespace StockChef.Application.DTOs.Products;

public class ProductDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Sku { get; set; } = string.Empty;

    public UnitOfMeasure UnitOfMeasure { get; set; }

    public decimal CurrentStock { get; set; }

    public decimal MinimumStock { get; set; }

    public decimal CostPrice { get; set; }

    public decimal SalePrice { get; set; }

    public Guid CategoryId { get; set; }

    public Guid SupplierId { get; set; }

    public bool IsActive { get; set; }
}