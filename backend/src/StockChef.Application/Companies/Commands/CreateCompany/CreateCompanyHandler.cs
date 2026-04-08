using MediatR;

public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, Guid>
{
    private readonly ICompanyRepository _repository;

    public CreateCompanyHandler(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company(request.Name, request.Document);

        await _repository.AddAsync(company);

        return company.Id;
    }
}