public class CompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }

    public List<UnitDto> Units { get; set; } = new();
}