using MediatR;

public class CreateUnitHandler : IRequestHandler<CreateUnitCommand, Guid>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitRepository _unitRepository;

    public CreateUnitHandler(
        ICompanyRepository companyRepository,
        IUnitRepository unitRepository)
    {
        _companyRepository = companyRepository;
        _unitRepository = unitRepository;
    }

    public async Task<Guid> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyRepository.GetByIdAsync(request.CompanyId);

        if (company == null)
            throw new Exception("Company not found");

        var unit = new Unit(request.Name, request.CompanyId);

        await _unitRepository.AddAsync(unit);

        return unit.Id;
    }
}