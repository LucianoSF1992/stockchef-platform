using MediatR;
using StockChef.Domain;

public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, List<CompanyDto>>
{
    private readonly ICompanyRepository _repository;

    public GetAllCompaniesHandler(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _repository.GetAllAsync();

        return companies.Select(CompanyMapper.ToDto).ToList();
    }
}