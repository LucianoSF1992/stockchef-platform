using StockChef.Domain.Common;

namespace StockChef.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    private Category()
    {
    }

    public Category(string name, string? description = null)
    {
        SetName(name);
        Description = description;
    }

    public void Update(string name, string? description)
    {
        SetName(name);
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    private void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be empty.");

        if (name.Length > 100)
            throw new ArgumentException("Category name cannot exceed 100 characters.");

        Name = name.Trim();
    }
}