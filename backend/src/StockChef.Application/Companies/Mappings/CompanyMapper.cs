using StockChef.Domain.Entities;

public static class CompanyMapper
{
    public static CompanyDto ToDto(Company company)
    {
        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
            Document = company.Document
        };
    }
}