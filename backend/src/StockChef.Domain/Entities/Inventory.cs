public class Inventory : ICompanyEntity
{
    public Guid Id { get; private set; }

    public Guid ProductId { get; private set; }
    public Product Product { get; private set; } = null!;

    public Guid UnitId { get; private set; }
    public Unit Unit { get; private set; } = null!;

    public decimal Quantity { get; private set; }

    public Guid CompanyId { get; private set; }

    private Inventory() { } // EF

    public Inventory(Guid productId, Guid unitId, decimal quantity, Guid companyId)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        UnitId = unitId;
        Quantity = quantity;
        CompanyId = companyId;
    }

    public void AddStock(decimal quantity)
    {
        if (quantity <= 0)
            throw new Exception("Quantidade inválida");

        Quantity += quantity;
    }

    public void RemoveStock(decimal quantity)
    {
        if (quantity <= 0)
            throw new Exception("Quantidade inválida");

        if (Quantity < quantity)
            throw new Exception("Estoque insuficiente");

        Quantity -= quantity;
    }
}