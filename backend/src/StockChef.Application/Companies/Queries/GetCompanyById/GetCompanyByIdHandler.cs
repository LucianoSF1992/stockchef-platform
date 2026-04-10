using MediatR;

public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDto?>
{
    private readonly ICompanyRepository _repository;

    public GetCompanyByIdHandler(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<CompanyDto?> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var company = await _repository.GetByIdAsync(request.Id);

        if (company is null)
            return null;

        return CompanyMapper.ToDto(company);
    }
}