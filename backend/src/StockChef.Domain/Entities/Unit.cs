public class Unit : ICompanyEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Guid CompanyId { get; private set; }
    public Company Company { get; private set; } = null!;

    private Unit() { } // 🔥 necessário pro EF

    public Unit(string name, Guid companyId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Nome da unidade é obrigatório");

        Id = Guid.NewGuid();
        Name = name;
        CompanyId = companyId;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}