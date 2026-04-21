public class Unit
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public Guid CompanyId { get; private set; }
    public Company Company { get; private set; } = null!;

    private Unit() { }

    public Unit(string name, Guid companyId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome é obrigatório");

        Id = Guid.NewGuid();
        Name = name;
        CompanyId = companyId;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}