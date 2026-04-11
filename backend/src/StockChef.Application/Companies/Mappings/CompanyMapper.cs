using StockChef.Domain.Entities;

public static class CompanyMapper
{
    public static CompanyDto ToDto(Company company)
    {
        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
            Document = company.Document,
            Units = company.Units?
                .Select(u => new UnitDto
                {
                    Id = u.Id,
                    Name = u.Name
                })
                .ToList() ?? new List<UnitDto>()
        };
    }
}