namespace StockChef.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal UnitPrice { get; private set; }
    public bool IsActive { get; private set; }

    private Product() { }

    public Product(string name, string description, decimal unitPrice)
    {
        Validate(name, unitPrice);

        Name = name;
        Description = description;
        UnitPrice = unitPrice;
        IsActive = true;
    }

    public void Update(string name, string description, decimal unitPrice)
    {
        Validate(name, unitPrice);

        Name = name;
        Description = description;
        UnitPrice = unitPrice;

        SetUpdated();
    }

    public void Deactivate()
    {
        IsActive = false;
        SetUpdated();
    }

    private void Validate(string name, decimal unitPrice)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required");

        if (unitPrice < 0)
            throw new ArgumentException("Unit price cannot be negative");
    }
}