namespace StockChef.Application.DTOs.Suppliers;

public class UpdateSupplierDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? TradeName { get; set; }

    public string Cnpj { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? ContactPerson { get; set; }
}