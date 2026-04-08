public class Company
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public List<Unit> Units { get; private set; } = new();

    public Company(string name, string document)
    {
        Id = Guid.NewGuid();
        Name = name;
        Document = document;
        CreatedAt = DateTime.UtcNow;
    }
}