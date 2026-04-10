using MediatR;

public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, Company?>
{
    private readonly ICompanyRepository _repository;

    public GetCompanyByIdHandler(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Company> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}