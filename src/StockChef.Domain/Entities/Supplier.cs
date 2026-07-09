using StockChef.Domain.Common;

namespace StockChef.Domain.Entities;

public class Supplier : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public string? TradeName { get; private set; }

    public string Cnpj { get; private set; } = string.Empty;

    public string? Email { get; private set; }

    public string? Phone { get; private set; }

    public string? ContactPerson { get; private set; }

    private Supplier()
    {
    }

    public Supplier(
        string name,
        string cnpj,
        string? tradeName = null,
        string? email = null,
        string? phone = null,
        string? contactPerson = null)
    {
        SetName(name);
        SetCnpj(cnpj);

        TradeName = tradeName;
        Email = email;
        Phone = phone;
        ContactPerson = contactPerson;
    }

    public void Update(
        string name,
        string cnpj,
        string? tradeName,
        string? email,
        string? phone,
        string? contactPerson)
    {
        SetName(name);
        SetCnpj(cnpj);

        TradeName = tradeName;
        Email = email;
        Phone = phone;
        ContactPerson = contactPerson;

        UpdatedAt = DateTime.UtcNow;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Supplier name cannot be empty.");

        if (name.Length > 150)
            throw new ArgumentException("Supplier name cannot exceed 150 characters.");

        Name = name.Trim();
    }

    private void SetCnpj(string cnpj)
    {
        if (string.IsNullOrWhiteSpace(cnpj))
            throw new ArgumentException("CNPJ cannot be empty.");

        Cnpj = cnpj.Trim();
    }
}