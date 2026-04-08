public class Unit
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public Guid CompanyId { get; private set; }
    public Company Company { get; private set; }

    public Unit(string name, Guid companyId)
    {
        Id = Guid.NewGuid();
        Name = name;
        CompanyId = companyId;
    }
}