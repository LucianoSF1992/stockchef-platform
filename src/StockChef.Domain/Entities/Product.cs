using StockChef.Domain.Common;
using StockChef.Domain.Enums;

namespace StockChef.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public string Sku { get; private set; } = string.Empty;

    public UnitOfMeasure UnitOfMeasure { get; private set; }

    public decimal CurrentStock { get; private set; }

    public decimal MinimumStock { get; private set; }

    public decimal CostPrice { get; private set; }

    public decimal SalePrice { get; private set; }

    public Guid CategoryId { get; private set; }

    public Category Category { get; private set; } = null!;

    public Guid SupplierId { get; private set; }

    public Supplier Supplier { get; private set; } = null!;

    private Product()
    {
    }

    public Product(
        string name,
        string sku,
        UnitOfMeasure unitOfMeasure,
        decimal minimumStock,
        decimal costPrice,
        decimal salePrice,
        Guid categoryId,
        Guid supplierId,
        string? description = null)
    {
        SetName(name);
        SetSku(sku);

        if (minimumStock < 0)
            throw new ArgumentException("Minimum stock cannot be negative.");

        if (costPrice < 0)
            throw new ArgumentException("Cost price cannot be negative.");

        if (salePrice < 0)
            throw new ArgumentException("Sale price cannot be negative.");

        UnitOfMeasure = unitOfMeasure;
        MinimumStock = minimumStock;
        CostPrice = costPrice;
        SalePrice = salePrice;

        CategoryId = categoryId;
        SupplierId = supplierId;

        Description = description;
        CurrentStock = 0;
    }

    public void ApplyStockMovement(
    StockMovementType type,
    decimal quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException(
                "Stock movement quantity must be greater than zero.");

        switch (type)
        {
            case StockMovementType.Entry:
                CurrentStock += quantity;
                break;

            case StockMovementType.Exit:
            case StockMovementType.Loss:
                if (CurrentStock < quantity)
                    throw new InvalidOperationException(
                        "Insufficient stock for this movement.");

                CurrentStock -= quantity;
                break;

            case StockMovementType.Adjustment:
                throw new InvalidOperationException(
                    "Adjustment movements require a specific adjustment rule.");

            default:
                throw new ArgumentOutOfRangeException(
                    nameof(type),
                    type,
                    "Invalid stock movement type.");
        }
    }

    public bool IsLowStock()
    {
        return CurrentStock <= MinimumStock;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty.");

        if (name.Length > 150)
            throw new ArgumentException("Product name cannot exceed 150 characters.");

        Name = name.Trim();
    }

    private void SetSku(string sku)
    {
        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("SKU cannot be empty.");

        Sku = sku.Trim().ToUpper();
    }
}